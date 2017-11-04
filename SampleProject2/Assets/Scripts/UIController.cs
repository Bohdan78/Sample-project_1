using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour, IUIController {


    [SerializeField]
    private Text pointsTxt, levelTxt;

    //public static UIController Instance { set; get; }

    private void Awake()
    {
        
    }

    void Start ()
    {
		
	}

    public void SetPoints(ScoreManager obj, int value)
    {
        pointsTxt.text = "Points: " + value;
    }

    public void SetLevel(ScoreManager obj, int value)
    {
        levelTxt.text = "Level: " + value;
    }

}
