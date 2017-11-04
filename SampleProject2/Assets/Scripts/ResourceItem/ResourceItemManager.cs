using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceItemManager : MonoBehaviour, IResourceItem
{
    private PolygonCollider2D myCollider;

    private SpriteRenderer myView;

    private GameObject myChildView;

    public float currentHealth, maxHealth;
    public float healthPoints { get { return currentHealth; } }

    private IHealthBar healthBar;
   // private IDataManager dataMaganer;
    private IReasorceItemPooler itemPooler;

    void Start()
    {
        myChildView = transform.GetChild(0).gameObject;
        myCollider = myChildView.GetComponent<PolygonCollider2D>();
        myView = myChildView.GetComponent<SpriteRenderer>();

        healthBar = transform.GetChild(1).GetComponent<IHealthBar>();
        itemPooler = transform.parent.GetComponent<IReasorceItemPooler>();

        //dataMaganer = GameObject.FindGameObjectWithTag("dataManager").GetComponent<IDataManager>();

        
    }

    private Vector2 DefineResourcePosition()
    {
        return new Vector2(Random.Range(20f, -20f), Random.Range(20f, -20f));
    }

    public void InitReasorce(IReasorceItemPooler obj, string signature, Vector2[] pikes, Sprite view, float health)
    {
        myView.sprite = view;
        myChildView.tag = signature;

        myCollider.pathCount = 1;
        myCollider.SetPath(0, pikes);

        maxHealth = health;
        currentHealth = maxHealth;

        transform.localPosition = DefineResourcePosition();
    }

    public void DealDamage(IResourceView obj, float damage)
    {
        currentHealth -= damage;
        healthBar.SetDamage(currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            itemPooler.SendScore(this, (int)maxHealth);
            itemPooler.InitResource(this);
            healthBar.ResetBarView();
        }
    }

    

}
