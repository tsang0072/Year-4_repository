using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    Vector2 moveInput;
    public float jumpForce;
    public float gravityMultiplier;
    [SerializeField]bool jumpInput;
    
    public LayerMask ground;
    public Transform grdChecker;
    [SerializeField]bool isGrounded;

    public bool flipped;
    public float flipSpeed;
    Quaternion flipL=Quaternion.Euler(0,180,0);
    quaternion flipR = Quaternion.Euler(0, 0, 0);
    public float respawnDelay = 8f;

    int levelNum = 0;
    [SerializeField] GameObject[] spawnPoints;

    public float rayLength;
    Rigidbody rb;
    Collider col;

    public AudioSource audioSource;
    bool IsMoving;
    
    AnimeController animeController;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        //rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        audioSource=GetComponent<AudioSource>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        animeController = AnimeController.instance;
    }
    void Update() 
    {
       moveInput.x=Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        if (moveInput.x != 0)
        {
            IsMoving = true;
            Debug.Log("Walking");
        }
        else
        {
            IsMoving = false;
        }
        if (IsMoving && !audioSource.isPlaying&&isGrounded)
        {
            audioSource.Play(); 
        }else if (!IsMoving||!isGrounded)
        {
            audioSource.Stop();
        }

       if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
       jumpInput=true;

       if(!flipped&&moveInput.x<0)
       {
            flipped=true;
       }else if(flipped&&moveInput.x>0)
       {
            flipped=false;
       }
        if (flipped)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipL, flipSpeed * Time.deltaTime);
        }
        else if (!flipped)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, flipR, flipSpeed * Time.deltaTime);
        }

 
    }
    void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravityMultiplier, ForceMode.Acceleration);
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        RaycastHit hit;

        if (Physics.Raycast(grdChecker.position, Vector3.down, out hit, rayLength, ground))
        {
            animeController.OnGround();
            isGrounded = true;
        }
        else
        {
            isGrounded = false;

        }

        if (jumpInput)
        {
            Jump();

        }

    }
    public void Die()
    {
        animeController.DiePlay();
        Debug.Log("Player died");
        StartCoroutine(Respawn());
    }

    void Jump()
    {
        rb.velocity = new Vector3(0f, jumpForce, 0f);
        jumpInput = false;
        animeController.JumpPlay();
    }

    public void FreezePlayer()
    {
        StartCoroutine(PauseMovement());
    }

    private IEnumerator Respawn()
    {
        //col.enabled = false;
        rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(2);

        transform.position = spawnPoints[levelNum].transform.position;
        transform.rotation = spawnPoints[levelNum].transform.rotation;
        rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(2);
        
        //col.enabled = true;

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Leve2_enter")
        {
            levelNum = 0;
            Debug.Log("Level 2 in");
            FreezePlayer();

        }
        else if (other.gameObject.name == "Leve3_enter")
        {
            levelNum = 1;
            Debug.Log("Level 3 in");
            FreezePlayer();
        }else if (other.gameObject.name == "Leve4_enter")
        {
            levelNum = 2;
            Debug.Log("Level 4 in");
            FreezePlayer();
        }     
    }


    IEnumerator PauseMovement() {
    //Backup and clear velocities
    Vector3 linearBackup = rb.velocity;
    Vector3 angularBackup = rb.angularVelocity;
    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    //Finally freeze the body in place so forces like gravity or movement won't affect it
    //rb.constraints = RigidbodyConstraints.FreezeAll;

    //Wait for a bit (two seconds)
    yield return new WaitForSeconds(2);
    //And unfreeze before restoring velocities
    //rb.constraints = RigidbodyConstraints.None;
    //restore the velocities
    rb.velocity = linearBackup;
    rb.angularVelocity = angularBackup;
}
}
