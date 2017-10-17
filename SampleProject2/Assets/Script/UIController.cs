using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

    [SerializeField]
    private bool click = true, click2 = false;

    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject[] buttonViwes;

	void Start ()
    {

    }
	
    public void SelectObject(Transform type)
    {
        Pooler.Instance.SpawnObject(type);
        CloseMenu(menu);
    }

    public void OpenMenu(GameObject ui)
    {
        if (!ui.activeInHierarchy && !click)
        {
            ui.SetActive(true);
            CameraController.Instance.SwitchMoveStatus();
            SwitchMButtonText(click, 0, 1);
        }
    }

    public void CloseMenu(GameObject ui)
    {
        if (ui.activeInHierarchy && click)
        {
            CameraController.Instance.SwitchMoveStatus();
            ui.SetActive(false);
            SwitchMButtonText(click, 0, 1);
        }
        click = !click;
    }

    public void ShowGrid(GameObject grid)
    {
        CameraController.Instance.BlockMoveCamera();
        click2 = !click2;
        if (!grid.activeInHierarchy)
            grid.SetActive(true);
        else
            grid.SetActive(false);
    }

    public void HideGrid(GameObject grid)
    {
        CameraController.Instance.AllowMoveCamera();
        SwitchMButtonText(click2, 2, 3);
    }

    public void Zoom()
    {
        CameraController.Instance.BlockMoveCamera();
        CameraController.Instance.SwitchZoomStatus();
    }

    public void ZoomPtUp()
    {
        CameraController.Instance.AllowMoveCamera();
    }



    private void SwitchMButtonText(bool clk, int m, int n)
    {
        if(clk)
        {
            buttonViwes[m].SetActive(true);
            buttonViwes[n].SetActive(false);
        }

        else if(!clk)
        {
            buttonViwes[m].SetActive(false);
            buttonViwes[n].SetActive(true);
        }

    }
}
