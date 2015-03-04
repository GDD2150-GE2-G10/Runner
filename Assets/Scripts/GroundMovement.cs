using UnityEngine;
using System.Collections;

public class GroundMovement : MonoBehaviour {

    private float velocityOffset = 0.5f;

    void Update () {
        float offset = Time.time * velocityOffset;                             
        renderer.material.mainTextureOffset = new Vector2(0, -offset); 
    }
}
