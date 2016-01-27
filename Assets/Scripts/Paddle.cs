using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			AutoPlay();
		} else {
			MoveWithMouse();
		}
		
	}
	
	void MoveWithMouse () {
		if (ball.Started()) {
			Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
			float MousePosInBlock = (Input.mousePosition.x / Screen.width) * 16;
		
			paddlePos.x = Mathf.Clamp(MousePosInBlock,0.5f,15.5f);
			this.transform.position = paddlePos;
		}
		
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(ball.transform.position.x,
										this.transform.position.y,
										0f);
		this.transform.position = paddlePos;
	}
}
