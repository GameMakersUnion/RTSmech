﻿using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {
	
	public GameObject Box;
	private GameObject BoxCopy;
	public GameObject Holder;
	private bool Selecting;
    private Vector2 BoxPosition;
	float x1;
	float x2;
	float y1;
	float y2;
    public Team selectableTeam;

	
	// Update is called once per frame
	void Update () {
		float x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
		float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		
	if(Input.GetMouseButtonDown(0)){
			x1=x;
			y1=y;
			Selecting=true;
			BoxCopy=(GameObject)Instantiate(Box);
			
        
		for(int i=0; i <Holder.transform.childCount; i++){
			Holder.transform.GetChild(i).GetComponent<Unit>().Selected=false;}
			//everything happens the one frame the mouse is pressed down
		}
		
	if(Selecting){
		x2=x;
		y2=y;
		
		float width=x2-x1;
		float height=y2-y1;
		BoxPosition= new Vector2(width/2+x1,height/2+y1);
	
		BoxCopy.transform.localScale=new Vector2(width,height);
		BoxCopy.transform.position=BoxPosition;
			
			
			
			
			
		
		}
	
	if(BoxCopy && Input.GetMouseButtonUp(0)){
			Selecting=false;
			for(int i=0; i <Holder.transform.childCount; i++){
				GameObject Child = Holder.transform.GetChild(i).gameObject;
				if((((Child.transform.position.x>x1 && Child.transform.position.x<x2) || 
					(Child.transform.position.x<x1 && Child.transform.position.x>x2)) && 
					((Child.transform.position.y>y1 && Child.transform.position.y<y2) || 
					(Child.transform.position.y<y1 && Child.transform.position.y>y2))) &&
                        (selectableTeam == Child.GetComponent<Unit>().team))
                {
					Child.GetComponent<Unit>().Selected=true;
				}
			}
			Destroy (BoxCopy);
			
		}
			
	
	}
}
