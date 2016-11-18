using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;
	public Text text;
	public int speed;
	private int score = 0;

	public float contactTime = 1000;

	float[] timeTracker;

	void OnCollisionStay(Collision collision){
		if (collision.gameObject.tag == "Enemy") {
			int t = collision.gameObject.GetComponent<EnemyScript> ().getId ();
			if(Time.time - timeTracker[t] > 1) {
				TakeDamage (10);
				timeTracker [t] = Time.time;
			}
		}
	}

	void Start(){
		timeTracker = new float[100];
		for(int a = 0; a < 100; a++)
		{
			timeTracker[a] = 0;
		}
	}

	public void TakeDamage(int amount)
	{
		Debug.Log ("took damage");
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			PlayerPrefs.SetInt ("score", score);
			Debug.Log("Player is Dead!");
			Application.LoadLevel (0);
		 }

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}
	public void scoreUpdater(){
		score += 1;
		text.text = "Score: " + score;
	}
}