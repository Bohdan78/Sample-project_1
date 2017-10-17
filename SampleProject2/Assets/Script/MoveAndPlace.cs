using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndPlace : MonoBehaviour {

    [SerializeField]
    private Transform pinetrees, rocks;

    private Vector3 seekPosition, mousePos;
    private Vector3 velocity = Vector3.zero;

    private Transform grid, platform;

    private int size;
    private float radius;

    public Transform container, placePrt;
    public ParticleSystem placeParticles;

    [SerializeField]
    private bool click, firsSpawn = true;
    public bool getFirstSpawn {  get { return firsSpawn; } }

    public static MoveAndPlace Instance { set; get; }

    private enum FirstQuewe : int { xUP, xBOTTOM, zLEFT, zRIGHT}
    FirstQuewe queweStatus = FirstQuewe.xUP;

    private void Awake()
    { 
        Instance = this;
    }

    void Start ()
    {
        grid = GameObject.FindGameObjectWithTag("grid").transform;
        platform = GameObject.FindGameObjectWithTag("platform").transform;
        Invoke("FirstSpawn", 0.25f);
    }

    public void SetObjectProp(int oSize, float oRadius)
    {
        size = oSize;
        radius = oRadius;
    }

    private void FirstSpawn()
    {
        float xMax = platform.localScale.x;
        float zMax = platform.localScale.z;

        if (queweStatus == FirstQuewe.xUP)
            StartCoroutine(CycleX(3, xMax, new Vector2(15, 19)));

        else if (queweStatus == FirstQuewe.xBOTTOM)
            StartCoroutine(CycleX(3, xMax, new Vector2(-15, -19)));

        else if (queweStatus == FirstQuewe.zLEFT)
            StartCoroutine(CycleZ(9, zMax, new Vector2(29, 34)));

        else if (queweStatus == FirstQuewe.zRIGHT)
        {
            StartCoroutine(CycleZ(9, zMax, new Vector2(-29, -34)));
            
        }



        
    }

    

    private IEnumerator CycleX(int start, float limit, Vector2 range)
    {
        for (int c = start; c < limit - 6; c += 3)
        {
            int random = Random.Range(0, 2);

            if (random == 0)
                Pooler.Instance.SpawnObject(pinetrees);
            else if (random == 1)
                Pooler.Instance.SpawnObject(rocks);

            Vector3 nPosition = new Vector3(-limit / 2 + c, 0, Random.Range(range.x, range.y));
            container.position = nPosition;
            DetectObjects.Instance.Scan(nPosition, radius);
            yield return null;
        }

        if (queweStatus == FirstQuewe.xUP)
        {
            queweStatus = FirstQuewe.xBOTTOM;
            FirstSpawn();
        }

        else if(queweStatus == FirstQuewe.xBOTTOM)
        {
            queweStatus = FirstQuewe.zLEFT;
            FirstSpawn();
        }
    }


    private IEnumerator CycleZ(int start, float limit, Vector2 range)
    {
        for (int c = start; c < limit - 6  ; c += 3)
        {
            int random = Random.Range(0, 2);

            if (random == 0)
                Pooler.Instance.SpawnObject(pinetrees);
            else if (random == 1)
                Pooler.Instance.SpawnObject(rocks);

            Vector3 nPosition = new Vector3(Random.Range(range.x, range.y), 0, -limit / 2 + c);
            container.position = nPosition;
            DetectObjects.Instance.Scan(nPosition, radius);
           // print(nPosition);
            yield return null;
        }

        if (queweStatus == FirstQuewe.zLEFT)
        {
            queweStatus = FirstQuewe.zRIGHT;
            FirstSpawn();
        }
        else if( queweStatus == FirstQuewe.zRIGHT)
            firsSpawn = false;

    }


    void Update ()
    {
        if (container != null && !firsSpawn)
        {
            mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            seekPosition = Camera.main.ScreenToWorldPoint(mousePos);
            seekPosition.y = 5f;
            container.position = Vector3.SmoothDamp(container.position, seekPosition, ref velocity, 0.25f);

            if (Input.GetMouseButtonDown(0))
                click = true;
            else if (Input.GetMouseButtonUp(0) && click)
                DetectObjects.Instance.Scan(container.position, radius);
        }
    }

    public void PlaceObject()
    {
       
        container.position = GridController.Instance.SelectCenter(new Vector3(container.position.x, 0, container.position.z), size);
        container.parent = grid;
        container.GetChild(0).gameObject.layer = 8;
        if (!firsSpawn)
        {
            placePrt.transform.position = container.position;
            placeParticles.Play();
            CameraController.Instance.SetDiffDistance();
        }
        container = null;
        click = false;
    }
}
