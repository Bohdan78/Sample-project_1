using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AreaDetector : MonoBehaviour {

	public static AreaDetector Instance { set; get; }

	[SerializeField]
	private List <Transform> emptyAreas;

	[SerializeField]
	private List <EmptyArea> emArScript;

	[SerializeField]
	private List <float> distances;

	[SerializeField]
	private List <float> radius;

	private enum queue : int {one, two, three, four, five};

	[SerializeField]
	private bool buttonTap;

	public int numberOfemAreas { get { return emArScript.Count; } }

	private void Awake()
	{
		Instance = this;
		foreach (Transform t in emptyAreas)
			emArScript.Add (t.GetComponent<EmptyArea> ());
	}

	private void Start()
	{
		
	}

	public void OnButton()
	{
		buttonTap = true;
	}

	public void CheckNearestCenter(Vector2 tap_point)
	{
		foreach (Transform emptyArea in emptyAreas) 
			distances.Add (GetDistance (tap_point, emptyArea.position));
		var min = distances.Min ();
		var currentIndex = distances.IndexOf (min);
		ShowCenter (currentIndex, tap_point);
	}
	
	private float GetDistance(Vector2 tap_point, Vector2 areaCenter)
	{
		return Vector2.Distance (tap_point, areaCenter);
	}

	private void ShowCenter(int index, Vector2 tap_point)
	{ 		
	    if (emArScript [index].CaluleteArea (tap_point))
			AnalyticsManager.Instance.EmptyTapCounter (index);
		distances.Clear ();
	}




}
