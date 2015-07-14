using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public Transform target;
	public float yOffset = 0;
	
	void Update() {
		this.transform.position = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
	}
}