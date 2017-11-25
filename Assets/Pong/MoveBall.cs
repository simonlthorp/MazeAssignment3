using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {

    //   public static Vector2 startPos;
    public static Vector2 stop;

    static Vector2 savedVelocity;
    static Vector2 velocity;
    static float savedAngularVelocity;
    public static float speed = 30.0f;
    static Rigidbody2D db;
    bool unPause = false;
    public static Vector3 pos;
    static Vector3 position = new Vector3(0, 0, 100);

    public void Start() {
        stop = new Vector2(0,0);
        db = GetComponent<Rigidbody2D>();
        pos = db.position;
        Serve(false,0);
    }


    void Update() {
        if (GblVars.isPaused) {
            savedAngularVelocity = db.angularVelocity;
            db.velocity = stop;

        }
        else {
            pos = new Vector3(db.position.x, db.position.y,100);
            savedVelocity = db.velocity;
        }
    }

    public static void Serve(bool goal, int dir) {

        if (goal == false) {
            if (dir == 0) {
                db.transform.position = position;
                db.velocity = Vector2.right * speed;
            }
            else {
                db.transform.position = pos;
                db.velocity = savedVelocity;
            }

            
        }
        else {
            if (dir == 1) {
                var vert = GameObject.Find("Paddle1");
                db.position = vert.transform.position;

            }
            else if (dir == 2) {
                var vert = GameObject.Find("Paddle2");
                db.position = vert.transform.position;
                db.velocity = Vector2.left * speed;
            }
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Paddle1") {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "Paddle2") {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

    }




}