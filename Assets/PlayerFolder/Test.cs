﻿using UnityEngine;
using System.Collections;


public class Test : MonoBehaviour {
    private Vector3 mouseposx;
    Vector3 whateverYouWant;
    Vector3 mouseCoords;
    public float speed;
    int counter;
    bool canJump = true;    
    //private Vector3 rayHitWorldPosition;
  // public Transform cube; 

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //float jumpSeed = 5; 
        //mouseposx = Input.mousePosition;
       //// Vector3 position = Camera.main.ScreenToWorldPoint(mouseposx);
       // float distance = transform.position.z - Camera.main.transform.position.z;
       // whateverYouWant = new Vector3(Input.mousePosition.x, 0, distance);
       // whateverYouWant = Camera.main.ScreenToWorldPoint(whateverYouWant);
       // transform.position = Vector3.Lerp(transform.position, whateverYouWant, speed * Time.deltaTime); 
        rigidbody.freezeRotation = true;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
      
        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            mouseCoords = new Vector3(hit.point.x, transform.position.y, transform.position.z);
        }

        float t = 0;
        t = Time.deltaTime * speed;
        transform.position = Vector3.Lerp(transform.position, mouseCoords, t);

        
        if (Input.GetKeyDown("space") && canJump == true)
        {
            transform.position += new Vector3(0, 2, 0);  
            counter = 40; 
            canJump = false;
        }

        if (canJump == false)
        {
            counter--;
        }
        if (counter <= 0)
        {
            canJump = true;
        }
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    //raycast
        //    RaycastHit rayhit; 
        //    if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), rayhit))
        //    {
        //        rayHitWorldPosition = rayhit.point;
        //        print("rayHit.point: " + rayhit.point + "(rayHitWorldPosition)");
        //        mouseposx = rayhit.point.x;
        //    }
        //    position.x = mouseposx; 
        //}
   
       
	
	}
}
