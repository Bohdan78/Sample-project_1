using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReasorceItemPooler : MonoBehaviour, IReasorceItemPooler
{
    public IResourceItem [] resourceItems;

    private IDataManager dataMaganer;
    private IScoreManager scoreManager;

    private enum ResourceType: int { SQUARE, TRIANGLE, PENTAGON}
    private ResourceType resourceType;

    private void Awake()
    {
        resourceItems = new IResourceItem[transform.childCount];
        foreach (Transform t in transform)
            resourceItems[t.GetSiblingIndex()] =  t.GetComponent<IResourceItem>();
    }

    void Start ()
    {
        dataMaganer = GameObject.FindGameObjectWithTag("dataManager").GetComponent<IDataManager>();
        scoreManager = GameObject.FindGameObjectWithTag("scoreManager").GetComponent<IScoreManager>();

        StartCoroutine("FirstPool");
    }

    public void SendScore(IResourceItem obj, int pts)
    {
        scoreManager.ScorePlus(this, pts);
    }
	
	public void InitResource(IResourceItem obj)
    {
        resourceType = (ResourceType)Rectifier(Random.Range(0, 6));
        string sign;

        switch (resourceType)
        {
            case ResourceType.SQUARE:
                sign = dataMaganer.squareSign;
                obj.InitReasorce(this, sign, dataMaganer.SetupPikes(this, sign), dataMaganer.SetupView(this, sign), dataMaganer.SetupHealth(this, sign));
                break;
            case ResourceType.TRIANGLE:
                sign = dataMaganer.triangleSign;
                obj.InitReasorce(this, sign, dataMaganer.SetupPikes(this, sign), dataMaganer.SetupView(this, sign), dataMaganer.SetupHealth(this, sign));
                break;
            case ResourceType.PENTAGON:
                sign = dataMaganer.hexagonSign;
                obj.InitReasorce(this, sign, dataMaganer.SetupPikes(this, sign), dataMaganer.SetupView(this, sign), dataMaganer.SetupHealth(this, sign));
                break;
        }
    }

    private int Rectifier(int number)
    {
        if (number <= 2)
            return 0;
        else if (number <= 4)
            return 1;
        else
            return 2;
    }

    private IEnumerator FirstPool()
    {
        foreach (IResourceItem c in resourceItems)
        {
            InitResource(c);
            yield return null;
        }
    }
}
