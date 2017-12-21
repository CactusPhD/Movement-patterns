using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour {

    public GameObject goal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnMouseDown(){
        //Debug.Log("mouse down");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)){
            //Debug.Log("ray hit");
            goal.transform.position = new Vector3(hit.point.x, .57f, hit.point.z);
        }
    }
}
