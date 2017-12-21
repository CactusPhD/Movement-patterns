using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidQualities : MonoBehaviour {

    public Vector3 direction;

    private void Awake()
    {
        Vector2 dir = Random.insideUnitCircle;
        direction = new Vector3(dir.x, 0, dir.y);
        direction = direction.normalized;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
