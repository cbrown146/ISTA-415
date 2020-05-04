using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Swingable : MonoBehaviour
{
    public float damage;
	
	public AudioSource source1;

    public PlayerSwordSwing playerSword;

    void OnCollisionEnter2D(Collision2D other)
    {

        PlayerSwordSwing p = other.gameObject.GetComponent<PlayerSwordSwing>();
        if (p)
        {
            print("collided sword");
            Physics2D.IgnoreCollision(p.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }

        source1.Play();
        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        if (damageable && playerSword.swordEquipped && playerSword.swordCollected && playerSword.canSwingSword)
        {
            print("sword collided with enemy");
            damageable.takeDamage(damage);
            playerSword.swingSword();
        }
    }

    void Update()
    {

        // Destroy the sword when you run out of swings
        if (playerSword.swings <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
