using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	int id;

	public void setId(int i){
		this.id = i;
	}

	public int getId(){
		return this.id;
	}
}
