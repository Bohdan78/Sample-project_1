using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toucher : MonoBehaviour {


	[SerializeField]
	private bool buttonTap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (point, Vector2.zero, 24f);
			if (hit.collider != null) 
			{
				print ("elem_tap");
			} 
			else if (hit.collider == null) 
			{
				if(!buttonTap)
					AreaDetector.Instance.CheckNearestCenter (point);
			}
		}

		if (Input.GetMouseButtonUp (0)) 
		{
			buttonTap = false;
		}
	}

	public void OnButton()
	{
		buttonTap = true;
	}
}
