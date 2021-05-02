using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class move : MonoBehaviour
{
    private Rigidbody rd;
    private Vector3 targetpos;
    private IEnumerator _mp;
    private RaycastHit rh = new RaycastHit();
    private Vector3 _s;
    [SerializeField] public AudioClip _hitWall;
    [SerializeField] private AudioClip _hitBack;
    [SerializeField] private AudioClip _hitFront;
    private AudioSource cp;
    [SerializeField] private GameObject SoundController;
    
    
    
    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        _mp = MoveToMousePos();
        cp = GetComponent<AudioSource>();
    

    }

    // Update is called once per frame
    void Update()
    {
        //  RaycastHit rh = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.right * 0.1f);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.left * 0.1f);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.forward * 0.1f);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.back * 0.1f);
        if (Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.up * 0.1f);
        if (Input.GetKey(KeyCode.Backspace))
            transform.Translate(Vector3.down * 0.1f);
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(_mp);
        if(Input.GetMouseButtonDown(1))
            StopCoroutine(_mp);
        
        if (Input.GetKey(KeyCode.B))
        {
            //var cp=GetComponent<AudioSource>();
            cp.clip = _hitBack;
            cp.Play();
        }
        
    }



    private void OnCollisionEnter(Collision other)
    {
        print(other.collider.tag);
        if (!enabled) return;
//        rd.isKinematic = enabled;
        if (other.collider.tag.Equals("Player-back"))
        {
            print("hitback");
            rd.AddForce(Vector3.forward * 0.1f);
            cp.clip = _hitBack;
            cp.Play();
        }

        else if (other.collider.tag.Equals("player-front"))//in ravesh doroste
        {
            print("hitfront");
            print(other.collider.name);
            Destroy(other.collider.gameObject);
            cp.clip = _hitFront;
            cp.Play();
        }

        else
        {
            
            cp.clip = _hitWall;
            cp.Play();
        }
    }




    private void OnCollisionStay(Collision other)
    {
        if (!enabled)return;
     //   rd.isKinematic = enabled;
        //print(other.collider.tag);
        cp.clip = _hitWall;
        cp.Play();
    }

    private void OnCollisionExit(Collision other)
    {
       //rd.isKinematic = !enabled;
    }

    public IEnumerator MoveToMousePos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rh))
            _s = rh.point;
        
        while (transform.position != _s)
        {

            targetpos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, _s, Time.deltaTime * 1f);
           //Vector3 w = new Vector3().magnitude;
            
                
            yield return null;
            
        }
        

    }
    
}
