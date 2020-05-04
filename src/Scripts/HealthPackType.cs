using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackType : MonoBehaviour
{
    public int healthAmount;
	//public AudioSource source1; 

    public void OnTriggerEnter2D(Collider2D collision)
    {
		//source1.Play();
        PlayerAttributes player = collision.gameObject.GetComponent<PlayerAttributes>();

        if (player != null)
        {
            player.addHealth(healthAmount);
            this.gameObject.SetActive(false);
        }
    }
}
