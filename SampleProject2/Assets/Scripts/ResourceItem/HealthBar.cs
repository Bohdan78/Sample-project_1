using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IHealthBar {

    private Slider healthBar;

    private Canvas myCanv;

	void Start ()
    {
        healthBar = transform.GetChild(0).GetComponent<Slider>();
        myCanv = gameObject.GetComponent<Canvas>();
        myCanv.worldCamera = Camera.main;

        
    }

    public void SetDamage(float health)
    {
        healthBar.value = health;
       // healthBar.transform.localPosition = Camera.main.WorldToScreenPoint(transform.parent.localPosition);
        if (healthBar.value < 1)
            healthBar.gameObject.SetActive(true);
    }

    public void ResetBarView()
    {
        healthBar.value = 1;
        healthBar.gameObject.SetActive(false);
    }

}
