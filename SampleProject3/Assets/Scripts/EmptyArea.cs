using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EmptyArea : MonoBehaviour {

	[SerializeField][Range(0,20)]
	private float x, y;

	[SerializeField]
	private float left, right, up, bottom;

	private float border_x, border_y;

	private Transform myTransform;
	private Vector3 startPosition;

	public GameObject leftView, upView;

	private SpriteRenderer field;

	public static EmptyArea Instance { set; get; }

	private void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		myTransform = transform;
		startPosition = myTransform.position;
		field = gameObject.GetComponent<SpriteRenderer> ();

		left = startPosition.x - x;
		right = startPosition.x + x;
		up = startPosition.y + y;
		bottom = startPosition.y - y;

	}

	private void Update()
	{
		left = startPosition.x - x;
		right = startPosition.x + x;
		up = startPosition.y + y;
		bottom = startPosition.y - y;

		field.size = new Vector2 (x*2, y*2);
	}

	public bool  CaluleteArea(Vector2 point)
	{
		//print ("CALLED");
		if (point.x < right && point.x > left && point.y < up && point.y > bottom)
			return true;
		else
			return false;
	}
}
