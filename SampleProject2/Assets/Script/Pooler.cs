using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour {

    [SerializeField]
    private Transform pinetrees, rocks;

    [SerializeField]
    private GameObject pinetree, rock;

    private Transform target;

    public static Pooler Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
		
	}

    private void FirstSpawn()
    {

    }

    public void SpawnObject(Transform pool)
    {
        try
        {
            pool.GetChild(0).gameObject.SetActive(true);
            MoveAndPlace.Instance.container = pool.GetChild(0);
            if (!MoveAndPlace.Instance.getFirstSpawn)
                CameraController.Instance.SetDiffDistance();
        }
        catch(UnityException ex)
        {
            if (ex.Message == "Transform child out of bounds")
            {
                //Instantiate()
            }
            Debug.Log(ex.Message);
            return;
        }
    }
	
}
