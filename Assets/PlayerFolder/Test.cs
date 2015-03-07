using UnityEngine;
using System.Collections;


public class Test : MonoBehaviour {
    Vector3 mouseCoords;
    public float speed;
    int counter;
	
    bool canJump = true;    
    //private Vector3 rayHitWorldPosition;
  // public Transform cube;

	PlayerCode playerRef;

	AudioClip jumpSound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
		GetComponent<PlayerCode> ();
		audioSource = GetComponent<AudioSource> ();

		jumpSound = Resources.Load ("SFX/Jump", typeof(AudioClip)) as AudioClip;
	}
	
	void Awake() {
		playerRef = GetComponent<PlayerCode>(); 
	}
	
	// Update is called once per frame
	void Update ()
	{
		playerRef.currentObject.rigidbody.freezeRotation = true;
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
            int jump = 450;
           	playerRef.currentObject.rigidbody.AddForce(transform.up * jump , ForceMode.Impulse);

            counter = 110; 
            canJump = false;

			audioSource.PlayOneShot(jumpSound, 0.5f);
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