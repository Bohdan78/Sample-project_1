using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleView : MonoBehaviour {

    [SerializeField]
    private List <Color> colors;

    private Renderer rend;

    private void Awake()
    {
        rend = gameObject.GetComponent<Renderer>();
    }

    void Start ()
    {
        
	}

    public void SetColor(int armorlvl)
    {
        rend.material.color = colors[Mathf.Clamp(armorlvl, 0, 2)];
    }
	
	
}
