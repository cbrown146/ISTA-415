using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float direction;
    public float chaseSpeed;
    public float collisionDamage;
    public GameObject player;
	public Transform groundedRayLeft;
	public float groundedRayLength;
	public float groundedRayLengthDetect;
	public Rigidbody2D body;
	private float jumpPower;
	public LayerMask groundLayer;
	public LayerMask groundLayerPlayer;
    public Animator animator;
	public AudioSource source1; //sounds of movement 
	public AudioSource source2; //sounds of collison with wall
	
	//private bool closeEnough = false;
	private bool musicOn = false;


    void Update()
    {		
		RaycastHit2D resultPlayer = Physics2D.Raycast(groundedRayLeft.position, groundedRayLeft.right, groundedRayLengthDetect, groundLayerPlayer.value);
		
		
		if(resultPlayer.collider != null){

			followPlayer();
		}
        else {
			resultPlayer = Physics2D.Raycast(groundedRayLeft.position, -1 * groundedRayLeft.right, groundedRayLengthDetect, groundLayerPlayer.value);
			if(resultPlayer.collider != null){
				direction *= -1;
				followPlayer();
			}
			else{
				normalWalk();
			}
		}
        animator.SetBool("Run", Mathf.Abs(direction) > 0f);
		
		
		playMusic(isCloseEnough());
    }

    // On collision with player, player takes damage
    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerAttributes player = other.gameObject.GetComponent<PlayerAttributes>();
        Swingable sword = other.gameObject.GetComponent<Swingable>();
        
        if ( player)
        {
            print("HIT");
            player.subtractHealth(collisionDamage);
			transform.gameObject.SetActive(false);
        }
    }
	
	void followPlayer(){

		if (direction < 0f){
		    body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (direction > 0f){
            body.transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
        }
			
		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
	}
	
	void normalWalk(){
		RaycastHit2D resultLeft = Physics2D.Raycast(groundedRayLeft.position, groundedRayLeft.right, groundedRayLength, groundLayer.value);
		
		if (resultLeft.collider != null){
		    direction *= -1;
			if(musicOn){
				source2.Play();
			}
        }
			
		if (direction < 0f){
			body.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        if (direction > 0f){
            body.transform.rotation = Quaternion.Euler(new Vector3(0, 180f, 0));
        }
			
	    body.velocity = new Vector2(direction * speed, body.velocity.y);
	}
	
	bool isCloseEnough(){
		if((player.transform.position.x - transform.position.x >= 5) || (player.transform.position.x - transform.position.x <= -5)){
			return false;
		}else{
			return true;
		}
	}
	
	void playMusic(bool ce){
		if (ce && !musicOn){
			source1.Play();
			musicOn = true;
		}else if(!ce && musicOn){
			musicOn = false;
			source1.Stop();
		}
	}
}
