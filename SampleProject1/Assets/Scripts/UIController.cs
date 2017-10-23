using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public static UIController Instance { set; get; }

    [SerializeField]
    private GameObject gameOverUI, startMenu;

    [SerializeField]
    private Text points, level;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    void Start ()
    {
        GameController.OnGameOver += SetGameOverUI;
        startMenu.SetActive(false);

    }

    public void SetGameOverUI()
    {
        if (gameOverUI.activeInHierarchy)
        {
            gameOverUI.SetActive(false);
            DisplayPoints(0);
            DisplayLevel(1);
        }
        else if (!gameOverUI.activeInHierarchy)
        {
            gameOverUI.SetActive(true);
        }
    }
	
    public void DisplayPoints(int pts)
    {
        points.text = "Points: " + pts;
    }

    public void DisplayLevel(int lvl)
    {
        level.text = "Level: " + lvl;
    }

    public void Restart()
    {
        SetGameOverUI();
        GameController.Instance.RestartGame(this);
    }
	
}
