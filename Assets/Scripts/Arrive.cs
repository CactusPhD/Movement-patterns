using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Arrive : MonoBehaviour {

    public GameObject goalObject;
    Vector3 goal;
    Vector3 start;

    private void Awake()
    {
        start = transform.position;
    }

    // Use this for initialization
    void Start () {
        updateGoal();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("Menu");
        }

        Vector3 direction = goal - transform.position;
        if (direction.magnitude <= .05) {
            transform.position = goal;
        }
        if (transform.position != goal){
            direction = direction.normalized;
            transform.position += direction / 30;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = start;
        }
        updateGoal();
	}

    void updateGoal()
    {
        goal = goalObject.transform.position;
    }
}
