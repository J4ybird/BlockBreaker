using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle  paddle;

	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	private float oldMousePosX;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		oldMousePosX = (Input.mousePosition.x / Screen.width);
	}
	
	// Update is called once per frame
	void OldUpdate () {
		float xPos=0;
		float xVelocity = 0;
		if (!hasStarted) {
			//Lock ball to the paddle till the mouse button has been press.
			this.transform.position = paddle.transform.position + paddleToBallVector; 
			xPos = (Input.mousePosition.x / Screen.width);
			xVelocity = (xPos - oldMousePosX) * 100f;
			//print( oldMousePosX + " " + xPos + " " + xVelocity);
			if (Input.GetMouseButton(0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(xVelocity,10f);
			}
			oldMousePosX = xPos;
		}					
	}
	
	void Update() {
		if (!hasStarted) {
			float xMod = 16f/Screen.width;
			float yMod = 16f/Screen.height;
			
			//Lock ball to the paddle till the mouse button has been press.
			this.transform.position = paddle.transform.position + paddleToBallVector; 
			
			
			Vector3 mousePos = Input.mousePosition;
			mousePos.Scale(new Vector3(xMod,yMod,0f));
			Vector3 relative = this.transform.InverseTransformPoint(mousePos);
			relative.Normalize();
			relative.Scale(new Vector3(10f,10f,0f));
			relative.y = Mathf.Abs(relative.y);
			
			if (Input.GetMouseButton(0)) {
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(relative.x,relative.y);
			}			
		}
	}
	
	
	
	
	void OnCollisionEnter2D (Collision2D col) {
		Vector2 tweakVelocity = new Vector2 (Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		
		//Ball does not trigger sound when brick is destroyed
		//Most likly cause brick is trigger first, it destroyes brick so the ball then never has collision 
		if (hasStarted) {
			this.rigidbody2D.velocity += tweakVelocity;
			audio.Play();
		}
	}
	
	public bool Started() {
		return hasStarted;
	}
}
