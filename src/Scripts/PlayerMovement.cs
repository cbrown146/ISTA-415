using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
	//private AudioSource source;
	public MoveSoundsMaker MSM;
	
    public float speed;
    public Rigidbody2D body;
    public Animator animator;  //Christopher added animator to Player Movement

    float horizontalInput;
    public float jumpPower;
    public Transform groundedRayOrigin;
    public float groundedRayLength;
    public LayerMask groundedLayer;
    private Vector2 previousDirection;
    private float speedUpDuration;
    private Boolean canRun = false;
    private float speedUpValue;
    public Boolean paused;
    public PlayerAttributes player;
    public Vector2 startPosition;
    void Update()
    {
        if (canRun) {
            speedUpDuration -= Time.deltaTime;
            if (speedUpDuration <= 0.0f) {
                speed -= speedUpValue;
                canRun = false;
            }
        }

        if (!paused)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            Vector2 moveDirection = body.velocity;
			//MSM.moveSound();
            if (((moveDirection.x < 0 && previousDirection.x < 0) || (moveDirection.x > 0 && previousDirection.x > 0)))
            {
                animator.SetBool("Jump", false);
                if (moveDirection.x > 0f)
                {
                    body.transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));

                }
                if (moveDirection.x < 0f)
                {

                    body.transform.rotation = Quaternion.Euler(new Vector3(0, 0f, 0));

                }
				
            }

            if (Input.GetButtonDown("Jump"))
            {
				
                RaycastHit2D result = Physics2D.Raycast(groundedRayOrigin.position, groundedRayOrigin.right, groundedRayLength, groundedLayer.value);

                //Debug.DrawLine(groundedRayOrigin.position, groundedRayOrigin.position + groundedRayOrigin.right
                //* groundedRayLength, Color.red, 50f);
                if (result.collider != null)
                {
                    print("Collided");
                    body.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
                    animator.SetBool("Jump", true);
					MSM.jumpSound();
                }
            }

            animator.SetBool("Run", Mathf.Abs(horizontalInput) > 0f);
        }
        
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        previousDirection = body.velocity;
        if(body.transform.position.y <= -20f)
        {
            player.loseALife();
        }
    }
    public void resetPosition()
    {
        body.transform.position = startPosition;
    }
    public void speedUpFor(float amount, float duration){
        speedUpValue = amount;
        speed += amount;
        speedUpDuration = duration;
        canRun = true;
    }

    public void OnCollisionEnter2D( Collision2D collision ) {
        if(collision.gameObject.tag == "Item")
        {
            print("1");
            MSM.collection();
        }
        Debug.Log( "Player touched " + collision.collider.name );
    }
}
