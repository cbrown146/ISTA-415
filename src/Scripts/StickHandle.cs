using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StickHandle : MonoBehaviour
{
    public float swingsToAdd;

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStickSwing player = other.gameObject.GetComponent<PlayerStickSwing>();
        if (player)
        {
            //source1.Play();
            if (player.canSwingStick)
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
                player.stickCollected = true;
                player.canSwingStick = true;
            }

            this.gameObject.SetActive(false);
        }
    }
}
