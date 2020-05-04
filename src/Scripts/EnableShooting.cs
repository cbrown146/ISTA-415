using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableShooting : MonoBehaviour
{
    public float ammoCount;
	//public AudioSource source1;
    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerShoot player = other.gameObject.GetComponent<PlayerShoot>();

        if (player)
        {
            print("gun hit");
			//source1.Play();
            if (player.canShoot)
            {
                player.ammo += ammoCount;
                if(player.ammo > player.maxAmmo)
                {
                    player.maxAmmo = player.ammo;
                }
            }
            else
            {
                player.ammo += ammoCount;
                player.canShoot = true;
            }

            this.gameObject.SetActive(false);
        }
    }
}
