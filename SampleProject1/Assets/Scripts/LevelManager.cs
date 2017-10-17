using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public delegate void TheDeath();
    public static event TheDeath OnDeath, OnRetrieve;

    public GameObject restartUI, tutorialUI;

    public static LevelManager Instance { set; get; }

    private void Awake()
    {
        Instance = this;
    }

    void Start ()
    {
        tutorialUI.SetActive(false);
    }

    public void RestartGame()
    {
        restartUI.SetActive(false);
        OnRetrieve();
    }

    public void EndGame()
    {
        restartUI.SetActive(true);
        OnDeath();
    }
	
	
	
}
