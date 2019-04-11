using UnityEngine;
using System.Collections;

namespace Drill
{   
	public class Loader : MonoBehaviour 
	{
		public GameObject gameManager;          //GameManager prefab to instantiate.
		public void Awake ()
		{
			gameObject.transform.position = new Vector3 (2.5f, -4.5f, -10f);
			if (GameManager.instance == null)
				Instantiate(gameManager);
		}

		public void GoMenu()
		{
			GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
			Destroy (gm);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		} 
	}
}