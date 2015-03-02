using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour 
{
	void Start () 
    {
        Debug.Log("Shape Bonus: " + Settings.PickupShapeBonus);
        Debug.Log("Color Mult: " + Settings.PickupColorMult);
        Debug.Log("Shape and Color Bonus: " + Settings.PickupShapeColorBonus);
        Debug.Log("Shape and Color Mult: " + Settings.PickupShapeColorMult);
	}
}
