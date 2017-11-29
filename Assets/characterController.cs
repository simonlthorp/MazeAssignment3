using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour {
    public float speed = 10.0f;
    public GameObject maze;
    private CapsuleCollider col;
    public BoxCollider[] cols;
    public AudioSource walk;

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

        if (translation != 0 || straffe != 0) {
            walk.mute = false;
        }
        else {
            walk.mute = true;
        }
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetButtonDown("Fire1")) {
            walkThroughWalls();
        }

        //return to start position
        if (Input.GetButtonDown("Fire2")) {
            transform.position = startPos;
        }

        if (Input.GetButtonDown("Cancel")) {
                Application.Quit();
        }

        if (Input.GetKeyDown("`")) {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetButtonDown("Throw"))
        {
            Fire();
        }

        if (Input.GetKeyDown("/")) {
            SceneChange.LoadTheLevel("Pong/MainScene");
        }

        //save game with F5 key or right stick down
        if (Input.GetButtonDown("Save"))
        {
            SaveState();
        }

        //Load game with F8 key
        if (Input.GetButtonDown("Load"))
        {
            LoadState();
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

    //Saves data
    void SaveState()
    {
        //save score
        PlayerPrefs.SetInt("score", score);

        //save player location
        PlayerPrefs.SetFloat("playerX", this.transform.position.x);
        PlayerPrefs.SetFloat("playerY", this.transform.position.y);

        //save enemy location
        PlayerPrefs.SetFloat("enemyX", GameObject.Find("dude").transform.position.x);
        PlayerPrefs.SetFloat("enemyY", GameObject.Find("dude").transform.position.y);

    }

    //Loads saved data
    void LoadState()
    {

        //Get saved score
        score = PlayerPrefs.GetInt("score");

        //Get saved player location
        float playerX = PlayerPrefs.GetFloat("playerX");
        float playerY = PlayerPrefs.GetFloat("playerY");

        //Get saved enemy location
        float enemyX = PlayerPrefs.GetFloat("enemyX");
        float enemyY = PlayerPrefs.GetFloat("enemyY");

        //set UI score
        scoreText.text = "Hits: " + score;

        //set player location
        transform.position = new Vector3(playerX, playerY);

        //set enemy location
        GameObject.Find("dude").transform.position = new Vector3(enemyX, enemyY);

    }

}
