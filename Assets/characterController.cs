using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject maze;
    private CapsuleCollider col;
    public BoxCollider[] cols;
    Vector3 startPos;

    public int score;
    private Text scoreText;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
        col = GetComponent<CapsuleCollider>();
        cols = maze.GetComponentsInChildren<BoxCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        startPos = transform.position;
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetAxisRaw("Fire1") != 0) {
            walkThroughWalls();
        }

        if (Input.GetAxisRaw("Fire2") != 0) {
            transform.position = startPos;
        }

        if (Input.GetAxisRaw("Cancel") != 0) {
                Application.Quit();
        }

        if (Input.GetKeyDown("`")) {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
	}

    void walkThroughWalls() {
        foreach(BoxCollider boxhCol in cols) {
            boxhCol.enabled = !boxhCol.enabled;
        }
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 2.0f);
    }

    public void ScoreUpdate()
    {
        score++;
        Debug.Log("Score: " + score);
        scoreText.text = "Hits: " + score;
    }
}
