using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer m_instance = null;

	void Awake () {
		if (m_instance != null) {
			Destroy(gameObject);
			Debug.Log ("Destorying gameObject");
		} else {
			m_instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	 }

}
