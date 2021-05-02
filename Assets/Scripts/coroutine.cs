using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coroutine : MonoBehaviour
{

    private IEnumerator a;
    private Transform _transform;
    [SerializeField] private float speed;
    

    private void Start()
    {
        _transform = transform;
        StartCoroutine(a=ienum(speed));
        
        
    }


    public IEnumerator ienum(float s)
    {
        
        while (true)
        {
            _transform.position+=Vector3.right*Time.deltaTime*s;
            yield return new WaitForSeconds(3f); // dasture khoruj az frame jari hastesh. dar frame badi az khate bade in dastur edame bede ta berese be akhare halghe va bargarde be while
            //waitforseconds() yek coroutine amae hastsh k sabr mikone vase ye modat zamane moshakhas bad edame mide
            
        }
        
        
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
            StopCoroutine(a);
    }

    public void PrintSampleTextWithButton()
    {
        Debug.Log("Error");
    }

   
}
