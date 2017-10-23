using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

    public IMeteorData meteorData;

    public enum spawnSide : int { RIGTH, LEFT, UP, DOWN };
    public spawnSide currentSide, targetSide;

    [SerializeField]
    private Vector2 spawnBorder;
    
    [SerializeField]
    private List <GameObject> meteors;

    public static MeteorSpawner Instance { set; get; }

    private int amount { get { return meteorData.amount; } }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;

        foreach (Transform child in transform)
            meteors.Add(child.gameObject);
    }

    void Start()
    {
        meteorData = GameObject.FindGameObjectWithTag("Controller").GetComponent<IMeteorData>();
        Init();
        GameController.OnGameOver += SetOffAll;
        GameController.OnStart += Init;
    }

    private void Init()
    {
        StartCoroutine("FirstSpawn");
    }

    private void SetOffAll()
    {
        foreach(GameObject child in meteors)
        {
            if (child.activeInHierarchy)
                child.SetActive(false);
        }
    }

    public void NewLevelPool()
    {
        SetOffAll();
        Invoke("Init", 0.25f);
    }

    private IEnumerator FirstSpawn()
    {
        for(int c = 0; c < amount; c++)
        {
            if(!meteors[c].activeInHierarchy)
            {
                ConfigAndPull(meteors[c]);
            }
            yield return null;
        }
    }

    public void ConfigAndPull(GameObject child)
    {
        currentSide = (spawnSide)Random.Range(0, 4);
        SelectTargetToMove();
        SpawnItem(SeletcPosition(currentSide), SeletcPosition(targetSide), child);
    }

    private Vector2 SeletcPosition(spawnSide side)
    {
        switch (side)
        {
            case spawnSide.DOWN:
                return new Vector2 (Random.Range(-spawnBorder.x, spawnBorder.x), -spawnBorder.y);
            case spawnSide.UP:
                return new Vector2 (Random.Range(-spawnBorder.x, spawnBorder.x), spawnBorder.y);
            case spawnSide.LEFT:
                return new Vector2 (-spawnBorder.x, Random.Range(-spawnBorder.y, spawnBorder.y));
            case spawnSide.RIGTH:
                return new Vector2 (spawnBorder.x, Random.Range(-spawnBorder.y, spawnBorder.y));
            default:
                return Vector2.zero;
        }
    }

    private void SpawnItem(Vector2 startPoint, Vector2 targetPoint, GameObject meteor)
    {
        meteor.transform.localPosition = startPoint;
        meteor.SetActive(true);
        meteor.SendMessage("SetTargetVector", targetPoint, SendMessageOptions.DontRequireReceiver);
    }

    private void SelectTargetToMove()
    {
        int k = Random.Range(0, 3);
        
        if(currentSide == spawnSide.DOWN)
        {
            if (k == 0)
                targetSide = spawnSide.UP;
            else if (k == 1)
                targetSide = spawnSide.RIGTH;
            else
                targetSide = spawnSide.LEFT;
        }
        else if (currentSide == spawnSide.UP)
        {
            if (k == 0)
                targetSide = spawnSide.DOWN;
            else if (k == 1)
                targetSide = spawnSide.RIGTH;
            else
                targetSide = spawnSide.LEFT;
        }
        else if (currentSide == spawnSide.RIGTH)
        {
            if (k == 0)
                targetSide = spawnSide.UP;
            else if (k == 1)
                targetSide = spawnSide.DOWN;
            else
                targetSide = spawnSide.LEFT;
        }
        else if (currentSide == spawnSide.LEFT)
        {
            if (k == 0)
                targetSide = spawnSide.UP;
            else if (k == 1)
                targetSide = spawnSide.RIGTH;
            else
                targetSide = spawnSide.DOWN;
        }
    }
 
}
