using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrease : MonoBehaviour {

    public static Text P1Score;
    public static Text P2Score;

    public static int score1 = 0;
    public static int score2 = 0;

    // Use this for initialization
    void Start() {
        P1Score = GameObject.Find("score1").GetComponent<Text>();
        P2Score = GameObject.Find("score2").GetComponent<Text>();
        Init();   
    }

    // Update is called once per frame
    void Update() {
        P1Score.text = score1.ToString();
        P2Score.text = score2.ToString();
    }

    public static void Init() {
        score1 = 0;
        score2 = 0;
    }

}

