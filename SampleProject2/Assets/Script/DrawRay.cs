using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(new Vector3(10, 1, 5), new Vector3(-10, 1, 5), Color.yellow);
        
	}
}
