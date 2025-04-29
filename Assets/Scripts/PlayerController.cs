using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed=10f;
    public float rotateSpeed=10f;
    Vector3 moveAmount;
    
    Animator anime;
    

    Rigidbody rb;
    void Start() 
    {
        rb=GetComponent<Rigidbody>();
        anime=GetComponent<Animator>();
        
    }
    void Update() 
    {
        Vector3 moveDirection=new Vector3(-Input.GetAxis("Horizontal"),0,-Input.GetAxis("Vertical")).normalized;
        
        moveAmount=moveDirection*moveSpeed*Time.deltaTime;
        
        
        if(Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
        {
            anime.SetBool("Walk",true);
            anime.SetBool("Idle",false);
        }else
        {
            anime.SetBool("Walk",false);
            anime.SetBool("Idle",true);
        }
        
 
        Vector3 targetDir=Vector3.Slerp(transform.forward,moveDirection,rotateSpeed*Time.deltaTime);
        transform.rotation=Quaternion.LookRotation(targetDir);
       
    }
    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position+moveAmount);
        
    }
}
