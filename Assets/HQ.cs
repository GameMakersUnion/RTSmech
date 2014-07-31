using UnityEngine;
using System.Collections;

public class HQ : MonoBehaviour {

    public Team team;
    int points;

	// Use this for initialization
	void Start () {
        points = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        Unit u = other.gameObject.GetComponent<Unit>();

        if (u != null && u.garbage != null && u.team == team)
        {
            Vector3 offset = new Vector3(Random.Range(2f, -2f), Random.Range(2f, -2f), 0f); ;
            u.garbage.transform.position = transform.position + offset;
            u.garbage.transform.parent = transform;
            GarbagePiece g = u.garbage;
            g.needsMining = true;
            u.garbage = null;
            points += g.points;
        }

        
    }

    
}
