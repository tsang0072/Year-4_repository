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
    public Transform respawnPoint;
    [SerializeField]bool isGrounded;

    public bool flipped;
    public float flipSpeed;
    Quaternion flipL=Quaternion.Euler(0,180,0);
    quaternion flipR = Quaternion.Euler(0, 0, 0);
    public float respawnDelay = 1f;

    public float rayLength;
    Rigidbody rb;
    //Renderer rend;
    Collider col;
    
    AnimeController animeController;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        //rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        animeController = AnimeController.instance;
    }
    void Update() 
    {
       moveInput.x=Input.GetAxis("Horizontal");
       moveInput.y=Input.GetAxis("Vertical");

       if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
       jumpInput=true;

       if(!flipped&&moveInput.x<0)
       {
            flipped=true;
       }else if(flipped&&moveInput.x>0)
       {
            flipped=false;
       }
       if(flipped)
       {
            transform.rotation=Quaternion.Slerp(transform.rotation, flipL, flipSpeed*Time.deltaTime);
       }else if(!flipped)
       {
            transform.rotation=Quaternion.Slerp(transform.rotation, flipR, flipSpeed*Time.deltaTime);
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
        Debug.Log("Player hit by laser!");
        StartCoroutine(Respawn());
    }

    void Jump()
    {
        rb.velocity = new Vector3(0f, jumpForce, 0f);
        jumpInput = false;
        animeController.JumpPlay();
    }
    
    private System.Collections.IEnumerator Respawn()
    {
        // Optional: temporary "death" effect
        //rend.enabled = false;
        col.enabled = false;
        rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        rb.velocity = Vector3.zero;

        //rend.enabled = true;
        col.enabled = true;

        Debug.Log("Player respawned!");
    }
}
