using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {

    public Team selectableTeam;

    //attack
    //harvest


    //Camera.main.ScreenToWorldPoint(Input.mousePosition )

    public Transform unitsSelected;
    private Vector3 target;

	// Use this for initialization
	void Start () {
        GameObject go = new GameObject("target");
        target = go.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //right click
	    if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = new Vector3(target.x, target.y, 0);

            Debug.Log(target);
            //destinationPosition = 

            //iterate through all children of units Selected and send the new target
            foreach (Transform unit in unitsSelected)
            {
                Debug.Log(unit.name);

                Unit u = unit.GetComponent<Unit>();
                if (selectableTeam == u.team)
                {
                    u.target = target;
                }
            }
        }
	}
}
