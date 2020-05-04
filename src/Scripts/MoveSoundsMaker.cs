using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSoundsMaker : MonoBehaviour
{
    //public AudioSource source1;    //move
    public AudioSource source2;    //jump
    public AudioSource source3;    //fire
    public AudioSource source4;    //swing
    public AudioSource source5;    //stickSwing
    public AudioSource source6;   //collecting sounds.
    public AudioSource source7;   //hurt sounds


    // Start is called before the first frame update
    void Start()
    {
        //source5 = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //source5.Play();
    }

    /**
	public void moveSound(){
		source1.Play();
	}
	*/

    public void jumpSound() {
        source2.Play();
    }

    public void shootSound() {
        source3.Play();
    }

    public void swingSound() {
        source4.Play();
    }

    public void stickSwing()
    {
        source5.Play();
    }

    public void collection()
    {
        source6.Play();
    }

    public void getHurt()
    {
        source7.Play();
    }

}
