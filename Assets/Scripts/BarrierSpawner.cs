using UnityEngine;
using System.Collections;

public class BarrierSpawner : MonoBehaviour {

    public GameObject barrier;
    public GameObject ground;

    float timeElapsed = 0;
    float spawnTimeThreshold = 0.5f;
    bool spawnBarrier = true;

    float leftBound;
    float rightBound;
    float heightLevelWithGround = 0.75f;
    float distanceOutForSpawning = 30f;

    void Start () {
        leftBound = -10f;
        rightBound = 10f;
    }

    void Update () {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTimeThreshold)
        {
            GameObject spawnedBarrier;
            if(spawnBarrier)
            {
                float xRange = Random.Range(leftBound, rightBound);
                spawnedBarrier = (GameObject)Instantiate(barrier);
                spawnedBarrier.transform.position = new Vector3(xRange, heightLevelWithGround, distanceOutForSpawning);
            }
            
            timeElapsed -= spawnTimeThreshold;
            spawnBarrier = !spawnBarrier;
        }
    }
}