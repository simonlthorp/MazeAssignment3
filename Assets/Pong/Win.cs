using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    public static Text P1;
    public static Text P2;
    public static TextMesh message;
    public static int s1;
    public GameObject obj;



	// Use this for initialization
	void Start () {
        P1 = GameObject.Find("P1").GetComponent<Text>();
        P2 = GameObject.Find("P2").GetComponent<Text>();
        message = GameObject.Find("Message").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
        int win = 5;
        MeshRenderer m = GameObject.Find("Message").GetComponent<MeshRenderer>();
        if (ScoreIncrease.score1 == win) {
            message.text = "Player 1\nWins!\nPress X to play again";
            m.enabled = true;
            GblVars.isPaused = true;
            if (Input.GetKeyDown(KeyCode.X)) {
                m.enabled = false;
                rePlay();
            }
        }
        else if(ScoreIncrease.score2 == win) {
            message.text = "Player 2\nWins!\nPress X to play again";
            m.enabled = true;
            GblVars.isPaused = true;
            if (Input.GetKeyDown(KeyCode.X)) {
                m.enabled = false;
                rePlay();
            }
        }

	}

    
    public static void rePlay() {
        MoveBall.Serve(false, 0);
        ScoreIncrease.Init();
        control.Init();
        GblVars.isPaused = false;
    }
}
