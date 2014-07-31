using UnityEngine;
using System.Collections;


public enum GarbageType { Bone,Pizza,Banana };


public class GarbagePiece : MonoBehaviour {

    public GarbageType garbage;
    public const int points = 1;
    public bool needsMining = false;  //for mining garbage cans and maybe stealing from other bases' HQ's.

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Unit u = other.gameObject.GetComponent<Unit>();
        if (u != null && u.garbage == null && !needsMining)
        {
            Transform Mouth = other.transform.Find("Head").Find("Mouth").transform;
            transform.position = Mouth.position;
            transform.parent = Mouth;
            u.garbage = this;
        }
    }
}
