using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public Vector3 target;
    private bool movingTowardsTarget = false;

    private float speed = 5f; 

	// Use this for initialization
	void Start () {
        if (target != null) 
        {
            movingTowardsTarget = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (movingTowardsTarget) 
        {
            //if arrives at target then { movingTowardsTarget = false; target = null; }
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

        }
	}

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
