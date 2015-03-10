using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
	public static GameObject playerRef;

	public static float scoreMult = 1.0f;
	public static float scoreMultDur = 0.0f;
	
	public static float score = 0.0f;
	public static float highScore = 0.0f;
	
	public static AudioClip powerupColor = Resources.Load<AudioClip> ("SFX/Pickup1");
	public static AudioClip powerupShape = Resources.Load<AudioClip> ("SFX/Pickup0");
	public static AudioClip powerupBoth = Resources.Load<AudioClip> ("SFX/Pickup2");
	public static AudioClip deathSound = Resources.Load<AudioClip> ("SFX/Death");
	public static bool startSpawning = false;

	void Update()
	{
		scoreMultDur = Mathf.Clamp(scoreMultDur - Time.deltaTime, 0, float.MaxValue);

		if (scoreMultDur <= 0) 
		{
			scoreMult = 1;
			scoreMultDur = 0;
		}
	}
}
