using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeController : MonoBehaviour
{
    Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
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
}
