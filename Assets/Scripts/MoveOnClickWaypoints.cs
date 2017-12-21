using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClickWaypoints : MonoBehaviour {

    public GameObject waypoint1;
    public GameObject waypoint2;
    bool selected1 = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            selected1 = !selected1;
        }
	}

    void OnMouseDown(){
        //Debug.Log("mouse down");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)){
            //Debug.Log("ray hit");
            if (selected1)
            {
                waypoint1.transform.position = new Vector3(hit.point.x, .57f, hit.point.z);
            }
            else
            {
                waypoint2.transform.position = new Vector3(hit.point.x, .57f, hit.point.z);
            }
        }
    }
}
