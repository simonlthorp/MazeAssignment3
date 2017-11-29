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

    public AudioSource Day, Night;

    // Use this for initialization
    void Start () {
		rend1= maze.GetComponentsInChildren<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3")) {
            changeShader();
        }

        if(Input.GetButtonDown("Fire4"))
        {
            ToggleDay();
        }

        if (Input.GetButtonDown("Mute")) {
            Day.mute = !Day.mute;
            Night.mute = !Night.mute;
        }

    }

    void changeShader() {
        if (foggy) {
            Day.volume = 0.5f;
            Night.volume = 1.0f;
            Day.enabled = true;
            Night.enabled = false;
            foreach (Renderer rend in rend1) {
                rend.material.shader = shader1;
            }
        }
        else {
            Day.volume = 0.25f;
            Night.volume = 0.5f;
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
            Day.enabled = true;
            Night.enabled = false;
            foreach (Renderer rend in rend1)
            {
                rend.material.shader = shader1;
            }
        }
        else
        {
            Day.enabled = false;
            Night.enabled = true;
            foreach (Renderer rend in rend1)
            {
                rend.material.shader = shader3;
            }
        }
        isDay = !isDay;
    }

}
