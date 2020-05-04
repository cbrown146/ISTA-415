using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHandle : MonoBehaviour
{
    public float swingsToAdd;
	
	//public AudioSource source1;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerSwordSwing player = other.gameObject.GetComponent<PlayerSwordSwing>();
        if (player)
        {
			//source1.Play();
            if (player.canSwingSword)
            {
                player.swings += swingsToAdd;
                if (player.swings > player.maxSwings)
                {
                    player.maxSwings = player.swings;
                }
            }
            else
            {
                player.swings += swingsToAdd;
                player.swordCollected = true;
                player.canSwingSword = true;
            }

            this.gameObject.SetActive(false);
        }
    }
}
