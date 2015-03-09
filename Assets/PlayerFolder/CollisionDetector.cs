using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

    void OnTriggerEnter(Collider collision) {
        string color = GetColor(name);
        string shape = GetShape(name);
        string collided = collision.gameObject.tag.ToLower();

        Debug.Log(collision.gameObject.name);

        switch (collided)
        {
            case "barrier":
                //Debug.Log("Dead");
                break;
            case "powerup":
                Debug.Log("Powerup");
                break;
        }
    }

    private string GetColor(string materialName) {
        return gameObject.renderer.material.name.Split(' ') [0].Split('_') [2].ToLower();
    }

    private string GetShape(string materialName) {
        return gameObject.name.ToLower();
    }
}
