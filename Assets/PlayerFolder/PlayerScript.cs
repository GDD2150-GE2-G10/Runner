using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    float scoreMult = 1.0f;
    float scoreMultDur = 0.0f;
    
    float score = 0.0f;

    public Shape shape { get; protected set; }
    public Color color { get; protected set; }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Pickup":
                var pickup = collision.gameObject.GetComponent<PickupScript>();

                if (pickup.color == color)   //calculate the mult first
                {
                    scoreMult += Settings.pickupColorMult;
                    scoreMultDur += Settings.pickupColorMultDur;
                    if (pickup.shape == shape)   //test for perfect match
                    {
                        scoreMult += Settings.pickupShapeColorMult;     //all perfect match values are additive
                        scoreMultDur += Settings.pickupShapeColorMultDur;
                        score += (Settings.pickupShapeBonus + Settings.pickupShapeColorBonus) * scoreMult;
                    }
                }

                else if (pickup.shape == shape)
                    score += Settings.pickupShapeBonus;

                break;
            default:
                break;
        }
    }
}
