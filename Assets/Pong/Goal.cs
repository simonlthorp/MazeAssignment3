using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public GameObject ball;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other) {
        if (gameObject.transform.name == "Right") {
            ScoreIncrease.score1++;
            MoveBall.Serve(true,1);
            
        }
        else {
            ScoreIncrease.score2++;
            MoveBall.Serve(true,2);
        }

    }

}
