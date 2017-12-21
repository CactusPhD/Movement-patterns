using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flee : MonoBehaviour {

    public GameObject goalObject;
    Vector3 goal;
    Vector3 start;

    // Use this for initialization
    private void Awake()
    {
        start = transform.position;
    }

    void Start () {
        updateGoal();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        Vector3 direction = transform.position - goal;
        direction = direction.normalized;
        transform.position += direction / 30;
        updateGoal();

        if (Input.GetKeyDown(KeyCode.R)){
            transform.position = start;
        }
	}

    void updateGoal()
    {
        goal = goalObject.transform.position;
    }
}
