using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverButton : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame
	public void onClick () {
		Debug.Log ("Clicked");
		Application.LoadLevel (1);
	}
}
