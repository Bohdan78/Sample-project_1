using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalyticsManager : MonoBehaviour {

    public List <int> areaCounters;

	public GoogleAnalyticsV4 GAv4;

	public static AnalyticsManager Instance { set; get; }

	private void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		for (int n = 0; n < AreaDetector.Instance.numberOfemAreas; n++)
			areaCounters.Add (0);
		GAv4.StartSession ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space))
        {
			SendEmptyTapAnalytics();
			SomethingLikeClear ();
        }
	}

	public void EmptyTapCounter(int index)
	{
//		name = "area" + index;
//		this.GetType ().GetField (name).SetValue (this, (int)this.GetType ().GetField (name).GetValue(this) + 1);
//		name = null;

		areaCounters[index] +=  1;

	}

	public void SendEmptyTapAnalytics()
	{
		for (int c = 0; c < areaCounters.Count; c++) 
		{
			GAv4.LogEvent (new EventHitBuilder ().SetEventCategory ("Empty_tap")
			.SetEventAction ("Tap")
			.SetEventLabel ("Empty_area_" + (c + 1))
			.SetEventValue (areaCounters [c]));
		}
	}

	private void SomethingLikeClear()
	{
		for (int c = 0; c < areaCounters.Count; c++)
			areaCounters [c] = 0;
			
	}





}
