using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;
    public float speed;
	
	void Start ()
    {
		
	}

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, Time.deltaTime * speed, 15f);
    }
}
