using UnityEngine;
using System.Collections;

public class Bin : MonoBehaviour {

    public bool usesSeparateLid;

    enum BinState { Open, Sealed }
    private BinState state;

    private bool isUpright;

    private Unit miner;


	// Use this for initialization
	void Start () {
        state = BinState.Sealed;
        isUpright = true;
        //hasMiner = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Unit u = other.gameObject.GetComponent<Unit>();
            if (u != null && miner == null )
            {
                
                if (u.state == Unit.State.Idling || u.state == Unit.State.Moving)
                {
                    Debug.Log("i should mine");
                    //begins mining
                    miner = u;
                    u.state = Unit.State.Mining;
                    u.Selected = false;
                    u.transform.parent = null; //temporary hack until Selection is integrated
                    u.anim.SetBool("moving", true); //this is simulating mining, an animation not discussed.
                    u.target = transform.position;
                    //miner.transform.rotation =  LATER

                    if (u.garbage != null) //has garbage, drops it to mine 
                    {
                        XferGarbageOwner(other.transform, null);
                    }

                }

                

            }
            //else
            //{
            //    Debug.Log("I'm not sure if this triggers an NRE, but if it does, and I'd like to know why");
            //}

        }

        //carried food gets dropped
    }


    //transfer owner
    void XferGarbageOwner(Transform from, Transform to)
    {
        from.parent = to; //effectively should just drop it where it is
        from.gameObject.GetComponent<Unit>().garbage = null;
    }
}
