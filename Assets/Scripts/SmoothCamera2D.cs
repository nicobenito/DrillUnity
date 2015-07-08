using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
	
	/*public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = new Vector3(transform.position.x,target.position.y,transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

		
	}*/

	public Transform target;
	public float yOffset = 0;
	
	void Update() {
		this.transform.position = new Vector3(transform.position.x, target.position.y + yOffset, transform.position.z);
	}
}