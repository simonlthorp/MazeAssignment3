﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {
    public Texture2D Texture;
    public Material mat;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
	}

}