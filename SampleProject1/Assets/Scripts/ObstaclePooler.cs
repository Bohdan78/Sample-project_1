using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour {

    public List<GameObject> obstacles;
    public static ObstaclePooler Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    } 

    void Start ()
    {
        LevelManager.OnDeath += SetOffAll;
        LevelManager.OnRetrieve += Init;
        Init();
	}

    public void Init()
    {
        StartCoroutine("Pool");
    }
	
	private void SetOffAll()
    {
        foreach (GameObject g in obstacles)
            g.SetActive(false);
    }

    public void RecallObstacle(ObstacleController obstacle)
    {
        obstacle.Restore();
    }

    IEnumerator Pool ()
    {
        foreach(GameObject g in obstacles)
        {
            g.SetActive(true);
            g.SendMessage("Init", null, SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(0.25f);
        }
        //yield return null;
    }

}
