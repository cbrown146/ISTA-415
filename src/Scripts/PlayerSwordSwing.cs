using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwordSwing : MonoBehaviour
{
    public Transform swingStartPoint;
    public Swingable swordPrefab;
    public Boolean canSwingSword;
    public Boolean swordEquipped;
    public Boolean swordCollected;
    public float swings;
    public float maxSwings;

    public Image swordSwingBar;
    public Image bigSwordSwingBar;
	
	public MoveSoundsMaker MSM;
    public Swingable sword;

    void Awake()
    {
        /*sword = Instantiate<Swingable>(swordPrefab, swingStartPoint.position, swingStartPoint.rotation);
        sword.playerSword = this;*/
        canSwingSword = false;
        swordEquipped = false;
        hideSword();
    }
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            if (swordEquipped && canSwingSword && swings > 0)
            {
                swings -= 1;
                swordSwingBar.fillAmount = swings / maxSwings;
                swordSwingBar.fillAmount = swings / maxSwings;
				
				MSM.swingSound();
            }
        }*/
    }

    public void showSword()
    {
        sword.transform.gameObject.SetActive(true);
        //sword.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void hideSword()
    {
        sword.transform.gameObject.SetActive(false);
    }

    public void swingSword()
    {
        swings -= 1;
        swordSwingBar.fillAmount = swings / maxSwings;
        swordSwingBar.fillAmount = swings / maxSwings;
    }
}
