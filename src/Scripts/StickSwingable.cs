using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSwingable : MonoBehaviour
{
    public float damage;

    public AudioSource source1;

    public PlayerStickSwing playerStick;

    void OnCollisionEnter2D(Collision2D other)
    {

        PlayerStickSwing p = other.gameObject.GetComponent<PlayerStickSwing>();
        if (p)
        {
            Physics2D.IgnoreCollision(p.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }

        source1.Play();
        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        if (damageable && playerStick.stickEquipped && playerStick.stickCollected && playerStick.canSwingStick)
        {
            print("stick collided with enemy");
            damageable.takeDamage(damage);
            playerStick.swingStick();
        }
    }

    void Update()
    {

        // Destroy the sword when you run out of swings
        if (playerStick.swings <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
