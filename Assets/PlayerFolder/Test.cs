﻿using UnityEngine;
using System.Collections;


public class Test : MonoBehaviour {
    Vector3 mouseCoords;
    public float speed;
    int counter;	
    bool canJump = true; 
	PlayerCode playerRef;

	// Use this for initialization
	void Start () 
    {
		GetComponent<PlayerCode> ();
       
	}
	
	void Awake() {
		playerRef = GetComponent<PlayerCode>(); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerRef.currentObject.rigidbody.freezeRotation = true;
        playerRef.currentObject.rigidbody.useGravity = true; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
      
        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
			mouseCoords = new Vector3(hit.point.x,playerRef.currentObject.transform.position.y, playerRef.currentObject.transform.position.z);
        }

        float t = 0;
        t = Time.fixedDeltaTime * speed;
		playerRef.currentObject.transform.position = Vector3.Lerp(playerRef.currentObject.transform.position, mouseCoords, t);
        
        if (Input.GetMouseButtonDown(0) && canJump == true)
        {
                int jump = 8;
                playerRef.currentObject.rigidbody.AddForce(transform.up * jump, ForceMode.Impulse);
                // playerRef.currentObject.transform.position = new Vector3(0, 3, 0); 
                counter = 100;
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
      
	}
}
