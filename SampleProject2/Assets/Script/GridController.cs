using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    public Material gridMaterial;
    private Renderer rend;

    [SerializeField]
    private Transform platform, verticalGroup, horizontalGroup;

    public float  maxLimitX, maxLimitZ;

    [SerializeField]
    private float platformSizeX, platformSizeZ;


    [SerializeField]
    private int cellSize;

    public static GridController Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        
        platformSizeX = platform.localScale.x;
        platformSizeZ = platform.localScale.z;
        rend = gameObject.GetComponent<Renderer>();
        FormGrid();   
    }

    public Vector3 SelectCenter(Vector3 input, int size)
    {
        float nX = 0, nZ = 0;

        if (size == 2)
        {
            nX = input.x < Mathf.RoundToInt(input.x) + 0.5f ? Mathf.RoundToInt(input.x) : Mathf.RoundToInt(input.x);
            nZ = input.z < Mathf.RoundToInt(input.z) + 0.5f ? Mathf.RoundToInt(input.z) : Mathf.RoundToInt(input.z);
            maxLimitX = platformSizeX / 2 - 1;
            maxLimitZ = platformSizeZ / 2 - 1;
        }

        else if(size == 3)
        {
            nX = Mathf.FloorToInt(input.x) > 0 ? Mathf.FloorToInt(input.x) + 0.5f : Mathf.CeilToInt(input.x) - 0.5f;
            nZ = Mathf.FloorToInt(input.z) > 0 ? Mathf.FloorToInt(input.z) + 0.5f : Mathf.CeilToInt(input.z) - 0.5f;
            maxLimitX = platformSizeX / 2 - 1.5f;
            maxLimitZ = platformSizeZ / 2 - 1.5f;
        }

        //print(input.x + " " + input.z + " " + nX + " " + nZ);
        return new Vector3(Mathf.Clamp(nX, -maxLimitX, maxLimitX), input.y , Mathf.Clamp(nZ, -maxLimitZ, maxLimitZ));
    }

    private void FormGrid()
    {
        for(int c = 0; c < platformSizeZ+1; c++)
        {
            CreateLine(horizontalGroup, c, platformSizeX);
        }

        for (int c = 0; c < platformSizeX + 1; c++)
        {
            CreateLine(verticalGroup, c, platformSizeZ);
        }


        horizontalGroup.localPosition = new Vector3(0, 0, -platformSizeZ / 2);
        verticalGroup.localPosition = new Vector3(-platformSizeX / 2, 0, 0);
        verticalGroup.localEulerAngles = new Vector3(0, 90, 0);
    }

    private void CreateLine(Transform parent, float distance, float size)
    {
        GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cube);
        line.name = "Line";
        line.transform.parent = parent;
        line.transform.localScale = new Vector3(size, 0.5f, 0.05f);
        line.transform.position = new Vector3(0, 0.5f, distance);
        line.GetComponent<Renderer>().material = gridMaterial;
    }
}
