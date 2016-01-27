using UnityEngine;
using System.Collections;

public class BottomCollider : MonoBehaviour {

	private LevelManager levelManager;
		
	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Collision on BottomCollider detected.");
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel ("Lose Screen");
	}
	
	//void OnTriggerEnter2D(Collider2D trigger) {
	//	Debug.Log ("Trigger on BottomCollider detected.");
	//	levelManager.LoadLevel ("Win Screen");
	//}
	
}
