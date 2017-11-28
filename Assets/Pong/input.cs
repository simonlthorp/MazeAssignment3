using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input : MonoBehaviour {
    static Camera cam;
    InputField txtBx;
    GameObject inp;
    GameObject userInput;
    public static bool vert = false;

    public Texture2D iTexture, dTexture;
    public Material mat;

    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;

        var input = gameObject.GetComponent<InputField>();

        userInput = GameObject.Find("InputField");


        var se = new InputField.SubmitEvent();
        se.AddListener(Submit);

        input.onEndEdit = se;
        input.text = "";
    }
	
    private void Submit(string arg0) {
        switch (arg0) {
        //change colors
            case "gray":
                cam.backgroundColor = Color.gray;
                GblVars.isPaused = false;
                userInput.SetActive(false);
                MoveBall.Serve(false, 2);
                break;
            case "black":
                cam.backgroundColor = Color.black;
                GblVars.isPaused = false;
                userInput.SetActive(false);
                MoveBall.Serve(false, 2);
                break;
            case "grey":
                cam.backgroundColor = Color.grey;
                GblVars.isPaused = false;
                userInput.SetActive(false);
                MoveBall.Serve(false, 2);
                break;
            case "invert":
                invert();
                GblVars.isPaused = false;
                userInput.SetActive(false);
                MoveBall.Serve(false, 2);
                break;
            case "2 Player":
                control.P2 = true;
                Win.rePlay();
                userInput.SetActive(false);
                break;
            case "1 Player":
                control.P2 = false;
                Win.rePlay();
                userInput.SetActive(false);
                break;
            //exit console
            case "exit":
                GblVars.isPaused = false;
                userInput.SetActive(false);
                MoveBall.Serve(false,2);
                break;
        }

        var input = gameObject.GetComponent<InputField>();

        input.text = "";
    }

    public void invert() {

        Color iColor = new Color();
        ColorUtility.TryParseHtmlString("#C300C7", out iColor);
        Color dColor = new Color();
        ColorUtility.TryParseHtmlString("#3CFF38", out dColor);

        if (vert == false) {
            cam.backgroundColor = Color.white;
            Win.message.color = Color.black;

            GameObject.Find("P1").GetComponent<Text>().color = iColor;
            GameObject.Find("P2").GetComponent<Text>().color = iColor;
            GameObject.Find("score1").GetComponent<Text>().color = iColor;
            GameObject.Find("score2").GetComponent<Text>().color = iColor;
            GameObject.Find("Text").GetComponent<Text>().color = iColor;
            GameObject.Find("Placeholder").GetComponent<Text>().color = iColor;

            mat.mainTexture = iTexture;

            vert = true;
        }
        else {
            cam.backgroundColor = Color.black;
            Win.message.color = Color.white;

            GameObject.Find("P1").GetComponent<Text>().color = dColor;
            GameObject.Find("P2").GetComponent<Text>().color = dColor;
            GameObject.Find("score1").GetComponent<Text>().color = dColor;
            GameObject.Find("score2").GetComponent<Text>().color = dColor;
            GameObject.Find("Text").GetComponent<Text>().color = dColor;
            GameObject.Find("Placeholder").GetComponent<Text>().color = dColor;

            mat.mainTexture = dTexture;

            vert = false;
        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
