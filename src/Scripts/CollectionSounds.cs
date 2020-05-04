using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionSounds : MonoBehaviour
{
    // Start is called before the first frame update
	public AudioSource source1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter2D(Collision2D other)
    {
		PlayerAttributes player = other.gameObject.GetComponent<PlayerAttributes>();

        if (player != null)
        {
            source1.Play();
        }
    }
	
}
