using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ZombieHealth : MonoBehaviour {

	public GameObject player;
	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;



	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;

			gameObject.GetComponent<AISpawn> ().removeMe ();
			Destroy (gameObject);
			GameObject.Find ("Player").GetComponent<PlayerHealth> ().scoreUpdater ();
			//gameObject.GetComponent<PlayerController> ().scoreUpdater ();
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}
}