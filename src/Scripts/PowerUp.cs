using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speedModifier;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            player.speed += speedModifier;
            this.gameObject.SetActive(false);
        }
    }
}
