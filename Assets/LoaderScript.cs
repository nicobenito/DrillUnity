using UnityEngine;
using System.Collections;

public class LoaderScript : MonoBehaviour {


	public void StartGame()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
	}
}
