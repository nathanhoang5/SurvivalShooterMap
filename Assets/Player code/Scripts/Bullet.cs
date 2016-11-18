using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int damage = 0;

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet")
			return;
		var hit = collision.gameObject;
		var health = hit.GetComponent<ZombieHealth>();
		if (health  != null)
		{
			health.TakeDamage(damage);
		}

		Destroy(gameObject);
	}
	
	public void setDamage(int d){
		this.damage = d;
	}
}
