using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFog : MonoBehaviour {
    public Shader shader1;
    public Shader shader2;
    public Shader shader3;
    public GameObject maze;
    public Renderer[] rend1;
    public Renderer rend2;
    bool foggy = false;
    bool isDay = true;
    bool isMusic = true;
    bool dMusic = true, nMusic = false;
    public AudioSource Day, Night;

    // Use this for initialization
    void Start () {
		rend1= maze.GetComponentsInChildren<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Fire3") != 0) {
            changeShader();
        }

        if(Input.GetAxisRaw("Fire4") != 0)
        {
            ToggleDay();
        }

        BGM();
    }

    void changeShader() {
        if (foggy) {
            foreach (Renderer rend in rend1) {
                rend.material.shader = shader1;
            }
        }
        else {
            foreach (Renderer rend in rend1) {
                rend.material.shader = shader2;
            }
        }
        foggy = !foggy;
    }

    private void ToggleDay()
    {
        if (isDay)
        {
            dMusic = true;
            nMusic = false;
            //Night.mute = true;
            foreach (Renderer rend in rend1)
            {
                rend.material.shader = shader1;
            }
        }
        else
        {
            dMusic = false;
            nMusic = true;
            //Night.mute = false;
            foreach (Renderer rend in rend1)
            {
                rend.material.shader = shader3;
            }
        }
        isDay = !isDay;
    }

    private void BGM() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            isMusic = !isMusic;
        }
        if (isMusic) {
            if (dMusic) {
                Day.mute = false;
                Night.mute = true;
            }
            if (nMusic) {
                Day.mute = true;
                Night.mute = false;
            }
        }
        else {
            Day.mute = true;
            Night.mute = true;
        }
    }
}
