using UnityEngine;
using System.Collections;

public enum Team { Racoons, Cats };


public class Unit : MonoBehaviour {

    public Team team;
    public bool Selected = false;
    public bool carrying = false;
    private bool moving = false;
    private Animator anim;
    public GarbagePiece garbage;

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
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
    //Vector3 v = transform.TransformPoint();

        //if (target != null)
        //{
        //    movingTowardsTarget = true;
        //}
        //if (movingTowardsTarget) 
        if (target != null)
        {
            moving = true;
            anim.SetBool("moving", moving);

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
                moving = false;
                anim.SetBool("moving", moving);
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
