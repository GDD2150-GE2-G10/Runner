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
					Globals.scoreMult += Tuning.PICKUP_COLOR_MULT;
					Globals.scoreMultDur += Tuning.PICKUP_COLOR_MULT_DUR;
					if (pickup.shape.ToString().ToLower() == shape)   //test for perfect match
					{
						Globals.scoreMult += Tuning.PICKUP_SHAPE_COLOR_MULT;     //all perfect match values are additive
						Globals.scoreMultDur += Tuning.PICKUP_SHAPE_COLOR_MULT_DUR;
						Globals.score += (Tuning.PICKUP_SHAPE_BONUS + Tuning.PICKUP_SHAPE_COLOR_BONUS) * Globals.scoreMult;
						Globals.playerRef.GetComponent<AudioSource>().PlayOneShot(Globals.powerupBoth, 0.5f);
					} 
					else 
						Globals.playerRef.GetComponent<AudioSource>().PlayOneShot(Globals.powerupColor, 0.5f);
				}
				
				else if (pickup.shape.ToString().ToLower() == shape) {
					Globals.score += Tuning.PICKUP_SHAPE_BONUS;
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
