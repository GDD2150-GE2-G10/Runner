using UnityEngine;
using System.Collections;

public class BarrierSpawner : MonoBehaviour {

    public GameObject barrier;
    public GameObject capsulePowerup;
    public GameObject cubePowerup;
    public GameObject spherePowerup;
    public GameObject ground;
    
    private Material blue, green, red;
    
    public GameObject[] shapes;
    public Material[] colors;

    private bool spawnPowerup = false;

    float timeElapsed = 0;
    bool spawnBarrier = true;

    float leftBound;
    float rightBound;
	float heightLevelWithGround;
    float distanceOutForSpawning = 80f;

    void Start () {

						heightLevelWithGround = barrier.collider.bounds.extents.y;
						leftBound = -6f;
						rightBound = 6f;

						blue = Resources.Load ("Cube_Mat_Blue", typeof(Material)) as Material;
						green = Resources.Load ("Cube_Mat_Green", typeof(Material)) as Material;
						red = Resources.Load ("Cube_Mat_Red", typeof(Material)) as Material;

						shapes = new GameObject[3];
						shapes [0] = capsulePowerup;
						shapes [1] = cubePowerup;
						shapes [2] = spherePowerup;

						colors = new Material[3];
						colors [0] = red;
						colors [1] = green;
						colors [2] = blue;
    }

    void Update () {
		if (Globals.startSpawning) {
						timeElapsed += Time.deltaTime;
						if (timeElapsed > Tuning.BARRIER_SPAWN_DELAY) {
								GameObject spawnedBarrier;
								GameObject spawnedPowerup;
								if (spawnBarrier) {
										spawnPowerup = ShouldCreatePowerup ();

										float xRange = Random.Range (leftBound, rightBound);
										spawnedBarrier = (GameObject)Instantiate (barrier);
										spawnedBarrier.transform.position = new Vector3 (xRange, heightLevelWithGround, distanceOutForSpawning);
                
										if (spawnPowerup) {
												spawnedPowerup = (GameObject)Instantiate (shapes [Random.Range (0, 3)]);
												int i = Random.Range (0, 3);	//pick a random color
												spawnedPowerup.renderer.material = colors [i];
												spawnedPowerup.GetComponent<PickupScript> ().color = (Color)i;
												spawnedPowerup.transform.position = new Vector3 (xRange, heightLevelWithGround + 1.5f, distanceOutForSpawning);
										}
								}
            
								timeElapsed -= Tuning.BARRIER_SPAWN_DELAY;
								spawnBarrier = !spawnBarrier;
						}
				}
    }

    private bool ShouldCreatePowerup() {
        int randomNumber = Random.Range(0, 100);
        return (randomNumber < Tuning.PICKUP_SPAWN_CHANCE);
    }
}