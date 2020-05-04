using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private PlayerMovement player;
    public float speedUpAmount;
    public float duration; 
	
	//public AudioSource source1;
    public void OnTriggerEnter2D(Collider2D other)


    {
        player = other.GetComponent<PlayerMovement>();

        if (player != null)
        {
			//source1.Play();
            player.speedUpFor(speedUpAmount, duration);
            this.gameObject.SetActive(false);
        }

    }
}
