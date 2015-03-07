using UnityEngine;
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
  
	AudioClip jumpSound;
	
	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
		GetComponent<PlayerCode> ();
		
		jumpSound = Resources.Load("SFX/Jump", typeof (AudioClip)) as AudioClip;
	}
	
	void Awake() {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<PlayerCode> ().currentObject.rigidbody.freezeRotation = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
      
        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
			mouseCoords = new Vector3(hit.point.x,GetComponent<PlayerCode>().currentObject.transform.position.y, GetComponent<PlayerCode>().currentObject.transform.position.z);
        }

        float t = 0;
        t = Time.fixedDeltaTime * speed;
		GetComponent<PlayerCode>().currentObject.transform.position = Vector3.Lerp(GetComponent<PlayerCode>().currentObject.transform.position, mouseCoords, t);

        
        if (Input.GetMouseButtonDown(0) && canJump == true)
        {
            int jump = 450;
           	GetComponent<PlayerCode>().currentObject.rigidbody.AddForce(transform.up * jump , ForceMode.Impulse);

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