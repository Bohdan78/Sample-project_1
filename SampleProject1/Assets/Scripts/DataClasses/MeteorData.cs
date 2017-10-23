using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Meteor Data", menuName = "Data/Meteor data" )]
public class MeteorData : ScriptableObject
{
    [SerializeField]
    private float healthMl;
    [SerializeField]
    private float speedMl;
    [SerializeField]
    private int amount;

    public float healthMultiplier {  get { return healthMl; } }
    public float speedMultiplier { get { return speedMl; } }
    public int totalAmount { get { return amount; } }

    public void DefaultValues()
    {
        healthMl = 1;
        speedMl = 1;
        amount = 8;
    }

    public void UpValues()
    {
        healthMl *= 1.25f;
        speedMl *= 1.25f;
        amount += 4;
    }
}
