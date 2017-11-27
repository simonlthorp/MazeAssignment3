using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {


    public static void LoadTheLevel(string theLevel) {
        SceneManager.LoadScene(theLevel);
    }
}
