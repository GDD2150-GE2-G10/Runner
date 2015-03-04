using UnityEngine;
using System.Collections;

public class BarrierMover : MonoBehaviour {

    private const float barrierVelocity = 0.5f;
    private const int viewThreshold = -15;

    void Update () {
        transform.Translate(0, 0, -barrierVelocity);
        if (transform.position.z < viewThreshold) {
            Destroy(gameObject);
        }
    }
}
