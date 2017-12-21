using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPresses : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

   public void loadArrive()
    {
        SceneManager.LoadScene("Arrive");
    }

    public void loadFlee()
    {
        SceneManager.LoadScene("Flee");
    }

    public void loadWander()
    {
        SceneManager.LoadScene("Wander");
    }

    public void loadInterpose()
    {
        SceneManager.LoadScene("Interpose");
    }

    public void loadFlocking()
    {
        SceneManager.LoadScene("Flocking");
    }
}
