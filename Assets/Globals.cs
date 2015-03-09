using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
	public static GameObject playerRef;

	public static float scoreMult = 1.0f;
	public static float scoreMultDur = 0.0f;
	
	public static float score = 0.0f;	
	
	public static AudioClip powerupColor = Resources.Load<AudioClip> ("SFX/Jump");
	public static AudioClip powerupShape = Resources.Load<AudioClip> ("SFX/PowerupPickup");
	public static AudioClip powerupBoth = Resources.Load<AudioClip> ("SFX/PowerupPickup");
	public static AudioClip deathSound = Resources.Load<AudioClip> ("SFX/Death");
}
