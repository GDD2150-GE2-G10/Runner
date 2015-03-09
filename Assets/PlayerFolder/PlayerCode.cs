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
    GameObject capsule;

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
        cube.AddComponent<CollisionDetector>();

        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(0, 0, 0);
		sphere.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
        sphere.SetActive (false);
        sphere.AddComponent<CollisionDetector>();

        capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule); //OH GOD WHY????
        capsule.transform.position = new Vector3(0, 0, 0);
		capsule.AddComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ; 
        capsule.SetActive (false); 
        capsule.AddComponent<CollisionDetector>();

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
        capsule.renderer.material = currentMaterial;

		color = Color.Red;
    }
	
	void Awake() 
	{
		Globals.playerRef = gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && currentObject != cube)
		{
			cube.SetActive(true); 
			cube.rigidbody.velocity = currentObject.rigidbody.velocity;
			cube.transform.position = currentObject.transform.position;
			currentObject.SetActive(false);
			currentObject = cube;
			shape = Shape.Cube;
        }
        else if (Input.GetKeyDown(KeyCode.X) && currentObject != sphere)
		{
			sphere.SetActive(true); 
			sphere.rigidbody.velocity = currentObject.rigidbody.velocity;
			sphere.transform.position = currentObject.transform.position;
			currentObject.SetActive(false);
			currentObject = sphere;
            shape = Shape.Sphere;
        }
        else if (Input.GetKeyDown(KeyCode.C) && currentObject != capsule)
		{
			capsule.SetActive(true); 
			capsule.rigidbody.velocity = currentObject.rigidbody.velocity;
			capsule.transform.position = currentObject.transform.position;
			currentObject.SetActive(false);
			currentObject = capsule;
            shape = Shape.Capsule;
        }

        if (Input.GetKeyDown(KeyCode.A) && currentMaterial != red)
        {
            currentMaterial = red;
            currentObject.renderer.material = currentMaterial;
            cube.renderer.material = currentMaterial;
            sphere.renderer.material = currentMaterial;
            capsule.renderer.material = currentMaterial;
			color = Color.Red;
        }
        else if (Input.GetKeyDown(KeyCode.S) && currentMaterial != green)
        {
            currentMaterial = green;
            currentObject.renderer.material = currentMaterial;
            cube.renderer.material = currentMaterial;
            sphere.renderer.material = currentMaterial;
            capsule.renderer.material = currentMaterial;
			color = Color.Green;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentMaterial != blue)
        {
            currentMaterial = blue;
            currentObject.renderer.material = currentMaterial;
            cube.renderer.material = currentMaterial;
            sphere.renderer.material = currentMaterial;
            capsule.renderer.material = currentMaterial;
			color = Color.Blue;
        }
    }
}
