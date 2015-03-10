using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	public GUIText guiText;

	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + Globals.score + "\nMult: " + Globals.scoreMult+ "\n" + Mathf.CeilToInt(Globals.scoreMultDur);
	}
}
