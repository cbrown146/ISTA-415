using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStickSwing : MonoBehaviour
{
    public Transform swingStartPoint;
    public StickSwingable stickPrefab;
    public Boolean canSwingStick;
    public Boolean stickEquipped;
    public Boolean stickCollected;
    public float swings;
    public float maxSwings;

    public Image stickSwingBar;
    public Image bigStickSwingBar;

    public MoveSoundsMaker MSM;
    public StickSwingable stick;

    void Awake()
    {
        canSwingStick = false;
        stickEquipped = false;
        hideStick();
    }

    public void showStick()
    {
        stick.transform.gameObject.SetActive(true);
    }

    public void hideStick()
    {
        stick.transform.gameObject.SetActive(false);
    }

    public void swingStick()
    {
        swings -= 1;
        stickSwingBar.fillAmount = swings / maxSwings;
        stickSwingBar.fillAmount = swings / maxSwings;
        MSM.stickSwing();
    }
}
