using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    public float moveSpeed = 45f;
    public float AIspeed = 10.0f;

    Vector3 move = Vector3.zero;
    public static Vector3 position1 = new Vector3(-110, 0, 100);
    public static Vector3 position2 = new Vector3(110, 0, 100);

    public static bool P2 = true;

    public float y1 = 0.0f;
    public float y2 = 0.0f;

    static GameObject p1, p2;
    // Use this for initialization
    void Start() {
        p1 = GameObject.Find("Paddle1");
        p2 = GameObject.Find("Paddle2");
        Init();
    }

    // Update is called once per frame
    void Update() {

        Vector3 clampedPositionA = p1.transform.position;
        clampedPositionA.y = Mathf.Clamp(p1.transform.position.y, -62, 62);
        p1.transform.position = clampedPositionA;
        Vector3 clampedPositionB = p2.transform.position;
        clampedPositionB.y = Mathf.Clamp(p2.transform.position.y, -62, 62);
        p2.transform.position = clampedPositionB;

        if (!GblVars.isPaused) {
            y1 = Input.GetAxis("Vertical1") * Time.deltaTime * moveSpeed;
            y1 = (input.vert == true) ? -y1 : y1;
            p1.transform.Translate(0, y1, 0);
            P2 = false;
            if (P2 == true) {
                y2 = Input.GetAxis("Vertical2") * Time.deltaTime * moveSpeed;

                y2 = (input.vert == true) ? -y2 : y2;
                p2.transform.Translate(0, y2, 0);
            }
            else {
                var Vert = GameObject.Find("Ball");
                y2 = Vert.transform.position.y - transform.position.y;
                if (y2 > 0) {
                    move.y = AIspeed * Mathf.Min(y2, 1.0f);
                }
                if (y2 < 0) {
                    move.y = -(AIspeed * Mathf.Min(-y2, 1.0f));
                }
                p2.transform.position += move * Time.deltaTime;
            }

        }
    }
    public static void Init() {
        p1.transform.position = position1;
        p2.transform.position = position2;
    }
}