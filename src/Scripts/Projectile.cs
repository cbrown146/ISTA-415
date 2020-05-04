using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float lifeTime;
    //public AudioSource source1;

    public PlayerShoot player;

    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable damageable = other.gameObject.GetComponent<Damageable>();
        Tilemap map = other.gameObject.GetComponent<Tilemap>();
        if (damageable)
        {
            //source1.Play();
            damageable.takeDamage(damage);
            Die();
        }
        else if (map)
        {
            Die();
        }
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        player.ProjectileDestroyed(this);
    }
}
