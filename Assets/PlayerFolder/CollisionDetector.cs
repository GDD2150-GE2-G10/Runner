using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

    void OnTriggerEnter(Collider collision) {
        string color = GetColor(name);
        string shape = GetShape(name);
        string collided = collision.gameObject.tag.ToLower();

        switch (collided)
        {
            case "barrier":
                //Destroy(gameObject);
				Globals.playerRef.GetComponent<AudioSource>().PlayOneShot(Globals.deathSound, 0.5f);
                break;
            case "powerup":
				var pickup = collision.gameObject.GetComponent("PickupScript") as PickupScript;
			
				if (pickup.color.ToString().ToLower() == color)   //calculate the mult first
				{
					Globals.scoreMult += Tuning.pickupColorMult;
					Globals.scoreMultDur += Tuning.pickupColorMultDur;
					if (pickup.shape.ToString().ToLower() == shape)   //test for perfect match
					{
						Globals.scoreMult += Tuning.pickupShapeColorMult;     //all perfect match values are additive
						Globals.scoreMultDur += Tuning.pickupShapeColorMultDur;
						Globals.score += (Tuning.pickupShapeBonus + Tuning.pickupShapeColorBonus) * Globals.scoreMult;
						Globals.playerRef.GetComponent<AudioSource>().PlayOneShot(Globals.powerupBoth, 0.5f);
					} 
					else 
						Globals.playerRef.GetComponent<AudioSource>().PlayOneShot(Globals.powerupColor, 0.5f);
				}
				
				else if (pickup.shape.ToString().ToLower() == shape) {
					Globals.score += Tuning.pickupShapeBonus;
					Globals.playerRef.GetComponent<AudioSource>().PlayOneShot(Globals.powerupShape, 0.5f);
				}

				Destroy(collision.gameObject);
				break;
			default:
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
