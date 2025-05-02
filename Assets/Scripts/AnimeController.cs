using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeController : MonoBehaviour
{
    public static AnimeController instance;
    Animator anime;

    void Awake() {
        if(!instance){
            instance=this;
        }else if(instance!=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        anime = GetComponent<Animator>();
        anime.SetBool("Grounded",true);
    }


    void Update()
    {
        if(Input.GetAxis("Horizontal")!=0)
        {
            anime.SetBool("Walk",true);
            anime.SetBool("Idle",false);
        }else
        {
            anime.SetBool("Walk",false);
            anime.SetBool("Idle",true);
        }
    }
    public void Jump(){
        anime.SetBool("Grounded",false);
    }
    public void OnGround(){
        anime.SetBool("Grounded",true);
    }
}
