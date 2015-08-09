using UnityEngine;
using System.Collections;

namespace Drill
{   
	public class Loader : MonoBehaviour 
	{
		public GameObject gameManager;          //GameManager prefab to instantiate.
		private float s_baseOrthographicSize;
		public void Awake ()
		{
			if (GameManager.instance == null)
				Instantiate(gameManager);
			// set the camera to the correct orthographic size (so scene pixels are 1:1)
			/*var height = 2*Camera.main.orthographicSize;
			var width = height*Camera.main.aspect;
			
			Camera.main.aspect = Screen.width / Screen.height;
			Camera.main.orthographicSize = Screen.height / 2f;*/
			//Camera Size = y / (2 * s);
			Camera.main.orthographicSize = Screen.height / (2f * 80f);
			/*s_baseOrthographicSize = Screen.height / 120f;
			Camera.main.orthographicSize = s_baseOrthographicSize;*/

			/*float xFactor = Screen.width / 600f;
			float yFactor = Screen.height  / 900f;*/
			//Camera.main.rect=new Rect(0,0,1,xFactor/yFactor);
		}
		/*public float orthographicSize = 5;
		public float aspect = 1.33333f;
		
		void Start()
		{
			Camera.main.projectionMatrix = Matrix4x4.Ortho(
				-orthographicSize * aspect, orthographicSize * aspect,
				-orthographicSize, orthographicSize,
				camera.nearClipPlane, camera.farClipPlane);
		}*/
	}
}