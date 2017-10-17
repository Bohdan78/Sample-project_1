using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjects : MonoBehaviour {

    public GameObject current, existed;
    public float distance;

    [SerializeField]
    private string onMapTag = "onMapObject";

    public LayerMask objOnMap;

    public static DetectObjects Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
		
	}

    private void Update()
    {
        distance = Vector3.Distance(existed.transform.position, current.transform.position);
    }

    public void Scan(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius, objOnMap);

        if (hitColliders.Length == 0)
        {
            MoveAndPlace.Instance.PlaceObject();
        }
       
    }
}
