using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wander : MonoBehaviour {

    public GameObject goal1;
    public GameObject goal2;
    Vector3 waypoint1;
    Vector3 waypoint2;
    Vector3 start;
    Vector3 goal;
    Vector3 refrence;
    Vector3 direction;
    float lastUpdate;

    private void Awake()
    {
        start = transform.position;
        lastUpdate = Time.time;
    }

    // Use this for initialization
    void Start () {
        updateWaypoints();
        goal = waypoint1;
        refrence = waypoint2;
        updateDirection();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Time.time - lastUpdate > 1.0) {
            lastUpdate = Time.time;
            updateDirection();
        }
        if ((goal - refrence).magnitude < (transform.position - refrence).magnitude) {
            direction = -direction;
            swapGoals();
        }
        transform.position += direction / 30;
        if (Input.GetKeyDown(KeyCode.R)) {
            transform.position = start;
        }
        updateWaypoints();
	}

    void updateWaypoints()
    {
        waypoint1 = goal1.transform.position;
        waypoint2 = goal2.transform.position;

        //if (waypoint1 == goal && waypoint2 != refrence)
        //{
        //    refrence = waypoint2;
        //} else 
        if (waypoint1 != goal && waypoint2 == refrence)
        {
            goal = waypoint1;
        }
        if (waypoint1 == refrence && waypoint2 != goal)
        {
            refrence = waypoint2;
        }
        //else if (waypoint1 != refrence && waypoint2 == goal)
        //{
        //    goal = waypoint1;
        //}
    }

    void swapGoals()
    {
        if(goal == waypoint1) {
            goal = waypoint2;
            refrence = waypoint1;
        }
        else {
            goal = waypoint1;
            refrence = waypoint2;
        }
    }

    void updateDirection(){
        Vector3 dir = goal - transform.position;
        dir = dir.normalized;
        Vector2 random = Random.insideUnitCircle;
        dir.x += random.x;
        dir.z += random.y;
        direction = dir.normalized;
    }
}
