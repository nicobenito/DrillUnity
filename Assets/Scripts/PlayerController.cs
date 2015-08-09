using UnityEngine;
using System.Collections;

namespace Drill
{

	public class PlayerController : MonoBehaviour
	{
		public float speed;
		public int life = 100;
		private Animator playerAnimator;
		[HideInInspector]public bool isAlive = true;
		[HideInInspector]public bool levelWin = false;
		private Vector3 wantedRotation;
		private Light stateLight;
		private Color newColor;
		private string redLight="#FF0005FF";
		private string greenLight="#00FF6BFF";
		private Vector2 fingerPos;

		void Awake()
		{
			playerAnimator = GetComponent<Animator> ();
			stateLight = GameObject.Find ("StateLight").GetComponent<Light>();
			Color.TryParseHexString (greenLight, out newColor);
			stateLight.color = newColor;
		}
		void OnCollisionEnter2D (Collision2D col)
		{
			if(col.gameObject.tag == "Block")
			{
				Destroy(col.gameObject);
				life = life-20;
				if(life<=40)
				{
					Color.TryParseHexString (redLight, out newColor);
					stateLight.color = newColor;
				}
			}
			CheckIfGameOver();
		}

		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.tag == "NextLevel") 
			{
				Debug.Log("NextLevel");
				levelWin=true;
			}
		}

		private void CheckIfGameOver ()
		{
			if (life <= 0) 
			{			
				isAlive = false;
				enabled = false;
			}
		}

		void Update ()
		{
			playerAnimator.SetFloat ("Life", life);
			//arrow keys movement
			float moveHorizontal = Input.GetAxis ("Horizontal");
			Vector2 movement = new Vector2 (moveHorizontal, -1);
			GetComponent<Rigidbody2D>().velocity = movement * speed;
			DrillRotation (moveHorizontal);

			//touch movement
			if (Input.touchCount > 0) 
			{
				fingerPos= Input.GetTouch(0).position;
				if(fingerPos.x < Screen.width/2)
					movement = new Vector2(-1,-1);
				else
					movement = new Vector2(1,-1);

				GetComponent<Rigidbody2D> ().velocity = movement * speed;
				DrillRotation (movement.x);

				/*if (Input.GetTouch (0).phase == TouchPhase.Moved) 
				{
					Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
					touchDeltaPosition = new Vector2 (Mathf.Clamp(touchDeltaPosition.x,-1,1), -1);
					GetComponent<Rigidbody2D> ().velocity = touchDeltaPosition * speed;
					DrillRotation (touchDeltaPosition.x);
				}*/
			}
			GetComponent<Rigidbody2D> ().position = new Vector2 
				(
					Mathf.Clamp (GetComponent<Rigidbody2D> ().position.x, 0f, 5f), 
					GetComponent<Rigidbody2D> ().position.y
				);

			//LightPong
			if (life <= 40)
				stateLight.intensity = Mathf.PingPong (Time.time * 8f, 5);

		}

		void DrillRotation(float movement)
		{
			transform.rotation = Quaternion.Euler (0,0,25*movement);
		}
	}
}