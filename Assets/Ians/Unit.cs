using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public Transform target;
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
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        }
	}

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
