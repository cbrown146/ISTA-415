using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    public Image refObject;
    public Sprite toChangeTo;
    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerShoot player = other.gameObject.GetComponent<PlayerShoot>();
        if (player)
        {
            print("Pickup something");
            refObject.GetComponent<Image>().sprite = toChangeTo;
            refObject.GetComponent<Image>().fillAmount = 1;
        }
    }
}
