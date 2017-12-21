using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interpose : MonoBehaviour {

    public GameObject goal1;
    public GameObject goal2;
    Vector3 waypoint1;
    Vector3 waypoint2;
    Vector3 start;
    Vector3 goal;

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
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        Vector3 direction = goal - transform.position;
        if (direction.magnitude <= .05) {
            transform.position = goal;
        }
        if (transform.position != goal) {
            direction = direction.normalized;
            transform.position += direction / 30;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = start;
        }
        updateGoal();
	}

    void updateGoal()
    {
        waypoint1 = goal1.transform.position;
        waypoint2 = goal2.transform.position;
        goal = (waypoint1 + waypoint2) / 2;
    }
}
