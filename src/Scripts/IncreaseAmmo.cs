using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAmmo : MonoBehaviour
{
    // Start is called before the first frame update
	public int ammoNums;
	//public AudioSource source1;
	
	public void OnTriggerEnter2D(Collider2D other)
    {
		
		PlayerShoot player = other.gameObject.GetComponent<PlayerShoot>();
		
        if(player != null)
        {
			//source1.Play();
			player.ammo += ammoNums;
            player.maxAmmo = player.ammo;
			transform.gameObject.SetActive(false);
        }
    }
}
