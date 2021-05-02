using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundControl : MonoBehaviour
{
    [SerializeField] private AudioClip _clip2;
    [SerializeField] public AudioClip _hitWall;
    private AudioSource cp;
    
    private void Start()
    {
       cp=GetComponent<AudioSource>();
       cp.Play();
       
       
    }

    private void Update()
    {
        // if (Input.GetKey(KeyCode.B))
        // {
        //     //var cp=GetComponent<AudioSource>();
        //     cp.clip = _clip2;
        //     cp.Play();
        // }
            
    }

    public void hitWalls()
    {
        cp.clip = _hitWall;
        cp.Play();
    }
}
