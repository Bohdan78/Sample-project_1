using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, IPlayerView
{

    private IPlayerController playerController;

    [SerializeField]
    private Sprite[] guns;

    [SerializeField]
    private string shootBool;

    private SpriteRenderer myGunView;

    private enum GunView: int { TANK, BULLETSHTORMER}
    private GunView viewType = 0;

    private Animator anim;

    void Start ()
    {
        playerController = transform.parent.GetComponent<IPlayerController>();
        anim = gameObject.GetComponent<Animator>();
        myGunView = transform.GetChild(0).GetComponent<SpriteRenderer>();
        myGunView.sprite = guns[(int)viewType];
    }

    public void SwitchGun(IPlayerController obj)
    {
        viewType += 1;
        myGunView.sprite = guns[(int)viewType];
        anim.speed *= 2;
    }

    public void Shoot(IPlayerController obj)
    {
        anim.Play("Shoot");
        //anim.SetBool(shootBool, true);
    }

    public void StopAnim()
    {
        anim.Play("Shoot");
        //anim.SetBool(shootBool, false);
        playerController.EnableShoot(this);
    }



}
