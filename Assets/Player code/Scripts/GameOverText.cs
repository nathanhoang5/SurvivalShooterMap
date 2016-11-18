using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {
	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "Score: " + PlayerPrefs.GetInt ("score");
	}
}
