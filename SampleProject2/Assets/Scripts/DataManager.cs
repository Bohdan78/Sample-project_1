using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour, IDataManager
{
    [SerializeField]
    private Vector2[] triangle;

    [SerializeField]
    private Vector2[] square;

    [SerializeField]
    private Vector2[] pentagon;

    [SerializeField]
    private Sprite[] resourceViews;

    [SerializeField]
    private string triangleSignature = "", squareSignature = "", pentagonSignature = "";

    public string triangleSign { get { return triangleSignature; } }
    public string squareSign { get { return squareSignature; } }
    public string hexagonSign { get { return pentagonSignature; } }

    [SerializeField]
    private float squareHealth = 0f, triangleHealth = 0f, pentagonHealth = 0f;

    public float triangleHP { get { return triangleHealth; } }
    public float squareHP { get { return squareHealth; } }
    public float pentagonHP { get { return pentagonHealth; } }

    [SerializeField]
    private float bulletDamage = 0f;
    
    public float bulletDmg { get { return bulletDamage; } }

    void Start ()
    {
		
	}

    public Vector2 [] SetupPikes(IReasorceItemPooler obj, string signature)
    {
        if(signature == triangleSign)
            return triangle;
      
        else if (signature == squareSign)
            return square;

        else
            return pentagon;
    }

    public Sprite SetupView(IReasorceItemPooler obj, string signature)
    {
        if (signature == squareSign)
            return resourceViews[0];
        
        else if (signature == triangleSign)
            return resourceViews[1];
        
        else
            return resourceViews[2];
    }

    public float SetupHealth(IReasorceItemPooler obj, string signature)
    {
        if (signature == triangleSign)
            return triangleHP;

        else if (signature == squareSign)
            return squareHP;

        else
            return pentagonHP;
    }
}
