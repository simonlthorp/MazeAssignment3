using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallHit : MonoBehaviour {
    public AudioSource wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            wall.Play();
            Debug.Log("Wall");
        }

    }
}
