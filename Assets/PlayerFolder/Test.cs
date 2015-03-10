using UnityEngine;
using System.Collections;


public class Test : MonoBehaviour {
    Vector3 mouseCoords;
    public float speed;
    int counter;	
    bool canJump = true; 
	PlayerCode playerRef;

	AudioClip jumpSound;
	AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
		playerRef = GetComponent<PlayerCode> ();
		audioSource = GetComponent<AudioSource> ();
		jumpSound = Resources.Load<AudioClip> ("SFX/Jump");
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
		
		if (canJump == false && IsGrounded())
		{
			canJump = true;
		}
        
        if (Input.GetMouseButtonDown(0) && canJump == true)
        {
                playerRef.currentObject.rigidbody.AddForce(transform.up * Tuning.PLAYER_JUMP_FORCE, ForceMode.Impulse);
                canJump = false;
				audioSource.PlayOneShot(jumpSound, 0.5f);
        }
      
	}

	private bool IsGrounded()
	{
		return Physics.Raycast(playerRef.currentObject.transform.position, -Vector3.up, playerRef.currentObject.collider.bounds.extents.y, 1 << 9);
	}
}
