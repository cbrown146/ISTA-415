using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    public Projectile bulletPrefab;
    public Transform bulletStartPoint;

    public int shotsAllowedAtATime;
    public Boolean canShoot;
    public Boolean gunEquipped;
    public float ammo;
    public float maxAmmo;

    public Image ammoBar;
    public Image bigAmmoBar;
	
	public MoveSoundsMaker MSM;

    public List<Projectile> projectilesShot = new List<Projectile>();

    private float preAmmo;

    private void Start()
    {
        preAmmo = ammo;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (gunEquipped && canShoot && shotsAllowedAtATime > projectilesShot.Count && ammo > 0)
            {
                Projectile newProjectile = Instantiate<Projectile>(bulletPrefab, bulletStartPoint.position, bulletStartPoint.rotation);
                newProjectile.player = this;

                projectilesShot.Add(newProjectile);
                ammo -= 1;
                ammoBar.fillAmount = ammo / maxAmmo;
                bigAmmoBar.fillAmount = ammo / maxAmmo;
                preAmmo = ammo;
				
				MSM.shootSound();
            }
        }

        //For collection sounds.
        if(ammo > preAmmo)
        {
            MSM.collection();
            preAmmo = ammo;
        }
    }

    public void ProjectileDestroyed(Projectile destroyed)
    {
        projectilesShot.Remove(destroyed);
    }
}
