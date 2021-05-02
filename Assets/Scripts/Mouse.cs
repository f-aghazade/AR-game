using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject child;
    private bool Selected = false;
     private GameObject go;
     private string _name;
     RaycastHit rh = new RaycastHit();
     private Ray ray;
     private move gCom, chComMove;
     private Mouse chComMouse;




     // Start is called before the first frame update
    void Start()
    {
       
        gCom = GetComponent<move>();
        chComMouse = character.GetComponent<Mouse>();
        chComMove = character.GetComponent<move>();

    }

    // Update is called once per frame
   void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit rh = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           
            if (Physics.Raycast(ray, out rh))
            {   
                go = rh.collider.gameObject;
                _name = go.transform.parent.name;
                print(_name);
                print(name);
                if ((rh.collider.name == "anime boy hair")&&(_name == name))
                {
                        gCom.enabled = true;
                        
                        chComMouse.enabled = false;
                        chComMove.enabled = false;
                   //     child.GetComponent<move>().enabled = false;
                        _name = name;
                    Selected = true;
                    
                }
                
                else if (_name.Contains("character"))
                {
                    gCom.enabled = false;
                    chComMouse.enabled = true;
                    chComMove.enabled = true;
                 //   child.GetComponent<move>().enabled = true;
                    Selected = true;
                    print(Selected);
                }
               
            }
            
            
        }


    }


    


}
