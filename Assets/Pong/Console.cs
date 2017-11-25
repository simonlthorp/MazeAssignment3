
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    //   Camera cam;
   GameObject userInput;
    InputField a;
	// Use this for initialization

	void Start () {
        userInput = GameObject.Find("InputField");
        a = FindObjectOfType<InputField>();
         userInput.SetActive(false);
     }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)/*&&Input.GetKey(KeyCode.LeftControl)*/) {
            userInput.SetActive(true);
            a.ActivateInputField();

            GblVars.isPaused = true;

        }

    }

}
