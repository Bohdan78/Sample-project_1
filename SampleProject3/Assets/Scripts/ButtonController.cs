using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonController : MonoBehaviour {


	public GoogleAnalyticsV4 GAv4;
	// Use this for initialization
	void Start () 
	{
		GAv4.StartSession ();
		//GAv4.DispatchHits ();
	}
	
	public void ButtonPush_1()
	{
//		print ("Button 1");
//		GAv4.LogEvent (new EventHitBuilder ().SetEventCategory("Button")
//			.SetEventAction("Press")
//			.SetEventLabel("Button 1 pressed")
//			.SetEventValue(23));
	}

	public void ButtonPush_2()
	{
//		print ("Button 2");
//		GAv4.LogEvent (new EventHitBuilder ().SetEventCategory("Button")
//			.SetEventAction("Press")
//			.SetEventLabel("Button 2 pressed")
//			.SetEventValue(24));
	}

	public void ButtonPush_3()
	{
//		print ("Button 3");
//		GAv4.LogEvent (new EventHitBuilder ().SetEventCategory("Button_Custom")
//			.SetEventAction("Press")
//			.SetEventLabel("Button 3 pressed")
//			.SetEventValue(25));
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (point, Vector2.zero, 24f);
			if (hit.collider != null) {
				GAv4.LogEvent (new EventHitBuilder ().SetEventCategory ("Something")
				.SetEventAction ("Tap")
				.SetEventLabel ("Element_tap")
				.SetEventValue (12));
				print ("elem_tap");
			} else if (hit.collider == null) {
				GAv4.LogEvent (new EventHitBuilder ().SetEventCategory ("EmtyArea_1")
				.SetEventAction ("Tap")
				.SetEventLabel ("Empty_tap")
				.SetEventValue (24));
				print ("empty_tap");
			}
		}
	}
	//
}
