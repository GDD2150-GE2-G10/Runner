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
    private const int POWERUP_THRESHOLD = 25;
    private bool spawnPowerup = false;

    float timeElapsed = 0;
    float spawnTimeThreshold = 0.5f;
    bool spawnBarrier = true;

    float leftBound;
    float rightBound;
    float heightLevelWithGround = 0.75f;
    float distanceOutForSpawning = 30f;

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
        colors [0] = blue;
        colors [1] = green;
        colors [2] = red;
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
                    spawnedPowerup.renderer.material = colors[Random.Range(0, 3)];
                    spawnedPowerup.transform.position = new Vector3(xRange,heightLevelWithGround + 2, distanceOutForSpawning);
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