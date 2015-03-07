using UnityEngine;
using System.Collections;

public class PlayerCode : MonoBehaviour
{
    float scoreMult = 1.0f;
    float scoreMultDur = 0.0f;
    
    float score = 0.0f;

	public GameObject currentObject { get; protected set; }
    GameObject cube;
    GameObject sphere;
    GameObject pyramid;

	Material currentMaterial;
    Material red;
    Material blue;
    Material green;

    public Shape shape { get; protected set; }
    public Color color { get; protected set; }

    // Use this for initialization
    void Start()
    {
        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 0);
		cube.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
		cube.SetActive (false);

        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0, 0, 0);
		sphere.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
		sphere.SetActive (false);

        pyramid = GameObject.CreatePrimitive(PrimitiveType.Capsule); //OH GOD WHY????
        pyramid.transform.position = new Vector3(0, 0, 0);
		pyramid.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ; 
		pyramid.SetActive (false); 

        currentObject = cube;
		shape = Shape.Cube;
		currentObject.SetActive (true); 

        red = Resources.Load("Cube_Mat_Red", typeof(Material)) as Material;
        green = Resources.Load("Cube_Mat_Green", typeof(Material)) as Material;
        blue = Resources.Load("Cube_Mat_Blue", typeof(Material)) as Material;
        currentObject.renderer.material = red;
        currentMaterial = currentObject.renderer.material;
		Debug.Log(currentObject.renderer.material);
		cube.renderer.material = currentMaterial;
        sphere.renderer.material = currentMaterial;
        pyramid.renderer.material = currentMaterial;

		color = Color.Red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentObject != cube)
        {
            Debug.Log("Z key pressed\nCurrent object changed to : " + currentObject);
            /*currentObject.renderer.enabled = false; 
			//currentObject.rigidbody.detectCollisions = false; 
            currentObject.renderer.enabled = true;
			currentObject.rigidbody.detectCollisions = true; 
			*/
			currentObject.SetActive(false);
			currentObject = cube;
			shape = Shape.Cube;
			currentObject.SetActive(true);	
        }
        else if (Input.GetKeyDown(KeyCode.X) && currentObject != sphere)
        {
            Debug.Log("X key pressed\nCurrent object changed to : " + currentObject);
            /*currentObject.renderer.enabled = false;
			currentObject.rigidbody.detectCollisions = false;
            currentObject.renderer.enabled = true;
			currentObject.rigidbody.detectCollisions = true; 
			*/
			currentObject.SetActive(false);
			currentObject = sphere;
			shape = Shape.Sphere;
			currentObject.SetActive(true); 
        }
        else if (Input.GetKeyDown(KeyCode.C) && currentObject != pyramid)
        {
            Debug.Log("C key pressed\nCurrent object changed to : " + currentObject);
           /* currentObject.renderer.enabled = false;
			currentObject.rigidbody.detectCollisions = false;

            currentObject.renderer.enabled = true;
			currentObject.rigidbody.detectCollisions = true; 
			*/
			currentObject.SetActive(false);
			currentObject = pyramid;
			shape = Shape.Pyramid;
			currentObject.SetActive(true); 
        }

        if (Input.GetKeyDown(KeyCode.A) && currentMaterial != red)
        {
            currentMaterial = red;
            currentObject.renderer.material = currentMaterial;
            cube.renderer.material = currentMaterial;
            sphere.renderer.material = currentMaterial;
            pyramid.renderer.material = currentMaterial;
            Debug.Log("A key pressed\nCurrent texture changed to: " + currentMaterial);
			color = Color.Red;
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentMaterial != green)
        {
            currentMaterial = green;
            currentObject.renderer.material = currentMaterial;
            cube.renderer.material = currentMaterial;
            sphere.renderer.material = currentMaterial;
            pyramid.renderer.material = currentMaterial;
            Debug.Log("D key pressed\nCurrent texture changed to: " + currentMaterial);
			color = Color.Green;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentMaterial != blue)
        {
            currentMaterial = blue;
            currentObject.renderer.material = currentMaterial;
            cube.renderer.material = currentMaterial;
            sphere.renderer.material = currentMaterial;
            pyramid.renderer.material = currentMaterial;
            Debug.Log("S key pressed\nCurrent texture changed to: " + currentMaterial);
			color = Color.Blue;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Pickup":
                var pickup = collision.gameObject.GetComponent<PickupScript>();

                if (pickup.color == color)   //calculate the mult first
                {
                    scoreMult += Settings.pickupColorMult;
                    scoreMultDur += Settings.pickupColorMultDur;
                    if (pickup.shape == shape)   //test for perfect match
                    {
                        scoreMult += Settings.pickupShapeColorMult;     //all perfect match values are additive
                        scoreMultDur += Settings.pickupShapeColorMultDur;
                        score += (Settings.pickupShapeBonus + Settings.pickupShapeColorBonus) * scoreMult;
                    }
                }

                else if (pickup.shape == shape)
                    score += Settings.pickupShapeBonus;

                break;
            default:
                break;
        }
    }
}
