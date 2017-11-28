using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    private AudioSource[] sounds;
    private AudioSource bounceSound;
    private AudioSource hitSound;
    private GameObject hitText;
    private MeshRenderer mesh;
    private Collider col;
    private characterController player;

	// Use this for initialization
	void Start () {

        sounds = GetComponents<AudioSource>();
        bounceSound = sounds[0];
        hitSound = sounds[1];

        hitText = GameObject.Find("hitText");
        mesh = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        player = GameObject.Find("Capsule").GetComponent<characterController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.name == "dude")
        {

            player.ScoreUpdate();
            hitSound.Play();
            mesh.enabled = false;
            
            col.enabled = false;
            
        }
        else
        {
            bounceSound.Play();
        }

        

    }

}
