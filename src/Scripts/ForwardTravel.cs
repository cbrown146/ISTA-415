using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardTravel : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = this.transform.TransformDirection(new Vector2(speed, 0f));
    }
}
