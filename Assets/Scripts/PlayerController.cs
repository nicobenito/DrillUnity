using UnityEngine;
using System.Collections;

namespace Drill
{

	public class PlayerController : MonoBehaviour
	{
		public float speed;
		public int life = 100;
		[HideInInspector]public bool isAlive = true;
		[HideInInspector]public bool levelWin = false;
		private Vector3 wantedRotation;

		void Awake()
		{
		}
		void OnCollisionEnter2D (Collision2D col)
		{
			if(col.gameObject.tag == "Block")
			{
				Destroy(col.gameObject);
				life = life-20;
				//Debug.Log("Drill life: " + life);
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

		void FixedUpdate ()
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");

			Vector2 movement = new Vector2 (moveHorizontal, -1);
			GetComponent<Rigidbody2D>().velocity = movement * speed;
			DrillRotation (moveHorizontal);

			/*if(Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				Debug.Log(touchDeltaPosition);
				touchDeltaPosition = new Vector2(touchDeltaPosition.x,-1);
				GetComponent<Rigidbody2D>().velocity = touchDeltaPosition;
			}*/

		}

		void DrillRotation(float movement)
		{
			transform.rotation = Quaternion.Euler (0,0,25*movement);
		}
	}
}