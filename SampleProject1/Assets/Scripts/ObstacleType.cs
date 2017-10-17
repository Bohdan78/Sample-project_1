using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleType : MonoBehaviour {

    private SpriteRenderer mySprite;
    private int damage = 1;
    public int getDamageValue { get { return damage; } }

    [SerializeField]
   // private List<string> defineType;

    public enum defineType: int { obstacleType1, obstacleType2, obstacleType3}
    public defineType type;

	void Start ()
    {
        mySprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        InitType();
    }
	
    

	private void InitType()
    {
        switch (type)
        {
            case defineType.obstacleType1:
                SetProperties(1, "obstacleType1");
                break;
            case defineType.obstacleType2:
                SetProperties(2, "obstacleType2");
                break;
            case defineType.obstacleType3:
                SetProperties(3, "obstacleType3");
                break;
            default:
                goto case defineType.obstacleType1;
                
        }
    }

    private void SetProperties(int dmg, string typeName, string spritePath = "")
    {
        gameObject.tag = typeName;
        damage = dmg;
        if(spritePath != "")
            mySprite.sprite = (Sprite)Resources.Load(spritePath, typeof(Sprite)); 
            //or AtlasManager.Instance.currentAtlas.GetSprite(spritePath); if using SpriteAtlas
    }
}
