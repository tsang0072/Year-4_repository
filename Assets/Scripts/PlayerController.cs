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
    //public float groundDist;
    public float jumpForce;
    [SerializeField]bool jumpInput;
    
    public LayerMask ground;
    public Transform grdChecker;
    [SerializeField]bool isGrounded;

    public bool flipped;
    public float flipSpeed;
    Quaternion flipL=Quaternion.Euler(0,180,0);
    quaternion flipR=Quaternion.Euler(0,0,0);

    public float rayLength;
    //public SpriteRenderer sr;
    // public SpriteRenderer sr_body;
    // public SpriteRenderer sr_wing;
    // public SpriteRenderer sr_leg1;
    // public SpriteRenderer sr_leg2;
    public Rigidbody rb;
    Animator anime;
    

    void Start() 
    {
        rb=GetComponent<Rigidbody>();
        anime=GetComponent<Animator>();
        
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
        rb.velocity=new Vector3(moveInput.x*moveSpeed, rb.velocity.y, moveInput.y*moveSpeed);   
        RaycastHit hit;
        if(Physics.Raycast(grdChecker.position, Vector3.down, out hit, rayLength, ground))
        {
            isGrounded=true;
        }
        else 
        {
            isGrounded=false;
        }

        if(jumpInput)
        Jump();

    }

    void Jump()
    {
        rb.velocity=new Vector3(0f, jumpForce, 0f);
        jumpInput=false;
    }
}
