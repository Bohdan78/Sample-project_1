using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void Game();
    public static event Game OnGameOver;
    public static event Game OnStart;

    private DataManager dataManager;

    private enum level : int { ONE, TWO, THREE};
    private level current = level.ONE;

    public int currentLevel { get { return (int)current; } }

    public static GameController Instance { set; get; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    void Start ()
    {
        dataManager = GameObject.FindGameObjectWithTag("Controller").GetComponent<DataManager>();
    }
	
	public void LevelUp(ScoreManager obj)
    {
        if(current == level.ONE)
            current = (level)1;
        else if (current == level.TWO)
            current = (level)2;
        UIController.Instance.DisplayLevel((int)current + 1);
        dataManager.mData.UpValues();
        MeteorSpawner.Instance.NewLevelPool();
    }

    public void RestartGame(UIController obj)
    {
        OnStart();
    }

    public void EndGame(PlayerController obj)
    {
        OnGameOver();
    }
}
