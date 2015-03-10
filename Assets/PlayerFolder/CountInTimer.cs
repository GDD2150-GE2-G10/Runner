using UnityEngine;
using System.Collections;

public class CountInTimer : MonoBehaviour
{
	int seconds = 4;
	public GUIText guiText;
	AudioClip beepLow, beepHigh;
	AudioSource audioSource;
	
	void Start ()
	{
		audioSource = GetComponent<AudioSource> ();
		beepLow = Resources.Load ("SFX/beepLow", typeof(AudioClip)) as AudioClip;
		beepHigh = Resources.Load ("SFX/beepHigh", typeof(AudioClip)) as AudioClip;
		InvokeRepeating ("Countdown", 1.0f, 1.0f);
		guiText.text = "R e a d y !";
	}

	void Countdown ()
	{
		seconds--;
		if (seconds >= 1) {
			guiText.text = seconds.ToString();
			audioSource.PlayOneShot(beepLow, 0.7f);
		} else if (seconds == 0) {
			guiText.text = "G O !";
			audioSource.PlayOneShot(beepHigh, 0.7f);
		} else {
			CancelInvoke ("Countdown");
			guiText.text = "";
			Globals.startSpawning = true;
		}
	}
}
