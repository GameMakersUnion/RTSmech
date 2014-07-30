using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public enum Team { Racoons, Cats };
    public Team team;

    //public Vector3? target = null;  //nullable!
    public Vector3? target;
    //private bool movingTowardsTarget = false;

    private const float regSpeed = 5f;
    private const float minSpeed = 0.001f;
    private float speed = regSpeed;
    private bool tooClose;

	// Use this for initialization
	void Start () {
        target = null;
        speed = regSpeed;
        tooClose = false;
	}
	
	// Update is called once per frame
	void Update () {

        //if (target != null)
        //{
        //    movingTowardsTarget = true;
        //}
        //if (movingTowardsTarget) 
        if (target != null)
        {
            //if arrives at target then { movingTowardsTarget = false; target = null; }
            float step = speed * Time.deltaTime;
            float distAway = Vector3.Distance(transform.position, (Vector3)target);


            if (distAway < 1 && speed > minSpeed)
            {
                tooClose = true;
                speed /= 2;
            }

            transform.position = Vector3.MoveTowards(transform.position, (Vector3)target, step);
            
            if (tooClose)
            {
                Start();
                //movingTowardsTarget = true;
            }

            


            //Rigidbody2D r = new Rigidbody2D();
            //r.AddForce(;//.add...
            

        }
	}

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}
