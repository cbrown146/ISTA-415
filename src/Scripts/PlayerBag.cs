using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBag : MonoBehaviour
{

    public Image refObject;
    public Sprite gun;
    public Sprite sword;
    public Sprite stick;
    public PlayerShoot playerShoot;
    public PlayerSwordSwing playerSwordSwing;
    public PlayerStickSwing playerStickSwing;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            refObject.GetComponent<Image>().sprite = gun;
            //playerShoot.canShoot = true;
            playerShoot.gunEquipped = true;
            playerSwordSwing.canSwingSword = false;
            playerSwordSwing.swordEquipped = false;
            playerSwordSwing.hideSword();
            playerStickSwing.canSwingStick = false;
            playerStickSwing.stickEquipped = false;
            playerStickSwing.hideStick();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            refObject.GetComponent<Image>().sprite = sword;
            playerShoot.gunEquipped = false;
            if (playerSwordSwing.swordCollected) { 
                playerSwordSwing.canSwingSword = true;
                playerSwordSwing.swordEquipped = true;
                playerSwordSwing.showSword();
            }
            playerStickSwing.canSwingStick = false;
            playerStickSwing.stickEquipped = false;
            playerStickSwing.hideStick();

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            refObject.GetComponent<Image>().sprite = stick;
            playerShoot.gunEquipped = false;
            if (playerStickSwing.stickCollected)
            {
                playerStickSwing.canSwingStick = true;
                playerStickSwing.stickEquipped = true;
                playerStickSwing.showStick();
            }
            playerSwordSwing.canSwingSword = false;
            playerSwordSwing.swordEquipped = false;
            playerSwordSwing.hideSword();
        }
    }
}
