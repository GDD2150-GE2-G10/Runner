using UnityEngine;
using System.Collections;

public class HighScoreDisplay : MonoBehaviour {
	
	public GUIText guiText;
	
	// Update is called once per frame
	void Update () {
		guiText.text = "High Score: " + Globals.highScore;
	}
}
