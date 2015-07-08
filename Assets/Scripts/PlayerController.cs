using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public int life = 100;
	private bool isAlive = true;

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Block")
		{
			Destroy(col.gameObject);
			life = life-20;
			Debug.Log("Drill life: " + life);
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 movement = new Vector2 (moveHorizontal, -1);
		GetComponent<Rigidbody2D>().velocity = movement * speed;

	}
}