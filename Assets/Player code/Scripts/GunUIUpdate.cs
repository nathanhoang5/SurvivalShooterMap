using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunUIUpdate : MonoBehaviour {

	string currentGunName = "";
	public Text text;

	// Use this for initialization
	void Start () {
		text.text = "";
	}

	// Update is called once per frame
	public void ReloadUpdate(){
		text.text = "Reloading... Please Wait!";
	}

	public void UpdateUI(int b, string g){
		Debug.Log ("b: " + b);
		text.text = "Gun: " + g + "\n Bullets: " + b;
	}
}