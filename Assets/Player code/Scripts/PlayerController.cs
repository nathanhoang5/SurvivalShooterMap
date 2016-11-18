using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	public int speed;

	float timer;

	public Gun[] guns;

	int[] intialBullets;
	int currentGun = 0;

	GunUIUpdate gunUpdater;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		intialBullets = new int[guns.Length];
		enabled = true;
		intialBullets [0] = 30;
		intialBullets [1] = 20;
		intialBullets [2] = 35;
		gunUpdater = GetComponent<GunUIUpdate> ();
	}

	void Update()
	{
		timer += Time.deltaTime;

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;


		transform.Translate(x*speed, 0, z*speed);

		if (Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;

		if (guns [currentGun].rapidFire) {
			if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && timer >= guns [currentGun].fireRate && guns [currentGun].bullets > 0 && Time.timeScale != 0) {
				CmdFire ();
			}

		} else {
			if ((Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) && timer >= guns [currentGun].fireRate && guns [currentGun].bullets > 0 && Time.timeScale != 0) {
				CmdFire ();
			}
		}
		if (guns [currentGun].bullets <= 0) {
			gunUpdater.ReloadUpdate ();
		}
		if (guns [currentGun].bullets <= 0 && timer > guns [currentGun].reloadTime) {
			guns [currentGun].bullets = intialBullets [currentGun];
			timer = 0;
			gunUpdater.UpdateUI (guns [currentGun].bullets, guns [currentGun].name);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			ChangeGun ();
			gunUpdater.UpdateUI (guns [currentGun].bullets, guns [currentGun].name);
		}
	}

	// This [Command] code is called on the Client …
	// … but it is run on the Server!
	void CmdFire()
	{
		timer = 0;
		guns [currentGun].bullets--;
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		bullet.GetComponent<Bullet> ().setDamage (guns [currentGun].damage);


		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 60;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);

		gunUpdater.UpdateUI(guns [currentGun].bullets, guns [currentGun].name);
	}

	public Gun getGun(){
		return guns [currentGun];
	}

	void ChangeGun(){
		currentGun = (currentGun + 1) % guns.Length;
	}
}