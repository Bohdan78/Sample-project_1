using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProperties : MonoBehaviour {

    public Vector2 size;
    public float radius;
    public string objName;
    public string id;

	void Start ()
    {
        objName = transform.parent.name;
        id = transform.parent.name + " " + transform.GetSiblingIndex();

    }

    private void OnEnable()
    {
        MoveAndPlace.Instance.SetObjectProp((int)size.x, radius);
    }

    private void OnMouseDown()
    {
        ObjectData();
    }

    void ObjectData()
    {
        Debug.Log("Object "+ objName + " . Size on map is: "+size+" . Unic id: "+id);
    }
	
	
}
