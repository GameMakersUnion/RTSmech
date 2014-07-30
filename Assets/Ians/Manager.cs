using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    //move to position
    //control position with mouse
    //test MoveTowards when hitting colliders in linear path
    //attack
    //harvest

    //Camera.main.ScreenToWorldPoint(Input.mousePosition )

    public Transform unitsSelected;
    public Transform destinationPosition;
    private Vector3 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //right click
	    if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(target);
            //destinationPosition = 

            //iterate through all children of units Selected and send the new target
            foreach (Transform unit in unitsSelected)
            {
                unit.GetComponent<Unit>().target = target;
            }
        }
	}
}
