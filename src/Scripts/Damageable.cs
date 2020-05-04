using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damageable : MonoBehaviour
{
    public float health;
    public AudioSource source1; //zombie hurt sounds
    public GameObject blood; 
    public void takeDamage(float amount)
    



    {
        source1.Play();
        health -= amount;
        if(health <= 0)
        {
            Instantiate(blood, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
