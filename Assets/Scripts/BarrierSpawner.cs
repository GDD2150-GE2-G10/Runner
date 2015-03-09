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

    private const int RANDOM_RANGE_MAX = 100;
    private const int POWERUP_THRESHOLD = 35;
    private bool spawnPowerup = false;

    float timeElapsed = 0;
    float spawnTimeThreshold = 0.5f;
    bool spawnBarrier = true;

    float leftBound;
    float rightBound;
    float heightLevelWithGround = 0.75f;
    float distanceOutForSpawning = 80f;

    void Start () {
        leftBound = -6f;
        rightBound = 6f;

        blue = Resources.Load("Cube_Mat_Blue", typeof(Material)) as Material;
        green = Resources.Load("Cube_Mat_Green", typeof(Material)) as Material;
        red = Resources.Load("Cube_Mat_Red", typeof(Material)) as Material;

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
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTimeThreshold)
        {
            GameObject spawnedBarrier;
            GameObject spawnedPowerup;
            if(spawnBarrier)
            {
                spawnPowerup = ShouldCreatePowerup();

                float xRange = Random.Range(leftBound, rightBound);
                spawnedBarrier = (GameObject)Instantiate(barrier);
                spawnedBarrier.transform.position = new Vector3(xRange, heightLevelWithGround, distanceOutForSpawning);
                
                if (spawnPowerup) {
                    spawnedPowerup = (GameObject)Instantiate(shapes[Random.Range(0, 3)]);
					int i = Random.Range(0, 3);	//pick a random color
                    spawnedPowerup.renderer.material = colors[i];
					spawnedPowerup.GetComponent<PickupScript>().color = (Color)i;
                    spawnedPowerup.transform.position = new Vector3(xRange,heightLevelWithGround + 1.5f, distanceOutForSpawning);
                }
            }
            
            timeElapsed -= spawnTimeThreshold;
            spawnBarrier = !spawnBarrier;
        }
    }

    private bool ShouldCreatePowerup() {
        int randomNumber = Random.Range(0, RANDOM_RANGE_MAX);
        return (randomNumber < POWERUP_THRESHOLD);
    }
}