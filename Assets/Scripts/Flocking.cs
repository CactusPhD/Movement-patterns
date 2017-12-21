using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flocking : MonoBehaviour {

    public GameObject boid;
    public GameObject goal1;
    public GameObject goal2;
    public int numBoids;
    Vector3 waypoint1;
    Vector3 waypoint2;
    Vector3 goal;
    Vector3 refrence;
    Vector3 CoM;
    Vector3 CoD;
    GameObject[] boids;
    public float minDistance;

    private void Awake()
    {
        boids = new GameObject[numBoids];
        //init boids
        for(int i = 0; i < numBoids; i++)
        {
            float randX = Random.Range(-20, 20);
            float randZ = Random.Range(-9, 9);
            boids[i] = Instantiate(boid, new Vector3(randX, .57f, randZ), Quaternion.identity);
        }
    }

    // Use this for initialization
    void Start () {
        updateWaypoints();
        goal = waypoint1;
        refrence = waypoint2;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        int pastGoal = 0;
        for(int i = 0; i < numBoids; i++)
        {
            Vector3 direction = Vector3.zero;
            
            //towards CoM
            direction += (CoM - boids[i].transform.position).normalized;
            //alignment
            direction += CoD;
            //to goal
            direction += (goal - boids[i].transform.position).normalized;
            direction /= 3;

            for (int j = 0; j < numBoids; j++)
            {
                Vector3 away = Vector3.zero;
                //check collision
                if (i != j && (boids[i].transform.position - boids[j].transform.position).magnitude < minDistance)
                {
                    direction += (boids[i].transform.position - boids[j].transform.position).normalized;
                }
            }
            direction = direction.normalized;
            direction.y = 0;
            BoidQualities bq = boids[i].GetComponent<BoidQualities>(); 
            bq.direction = direction;
            boids[i].transform.position += direction / 30;
            if((boids[i].transform.position - refrence).magnitude >= (refrence - goal).magnitude)
            {
                //Debug.Log("Past goal");
                pastGoal++;
            }
        }
        if (pastGoal >= (numBoids / 2) - 1) {
            //Debug.Log("swap");
            swapGoals();
        }
        updateWaypoints();
        updateCoM();
	}

    void updateWaypoints()
    {
        waypoint1 = goal1.transform.position;
        waypoint2 = goal2.transform.position;

        if (waypoint1 != goal && waypoint2 == refrence)
        {
            goal = waypoint1;
        }
        if (waypoint1 == refrence && waypoint2 != goal)
        {
            refrence = waypoint2;
        }
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

    void updateCoM()
    {
        Vector3 tCoM = Vector3.zero;
        Vector3 tCoD = Vector3.zero;
        for(int i = 0; i < numBoids; i++)
        {
            tCoD += boids[i].GetComponent<BoidQualities>().direction;
            tCoM += boids[i].transform.position;
        }
        CoM = tCoM / numBoids;
        CoD = (tCoD / numBoids).normalized;

    }

}
