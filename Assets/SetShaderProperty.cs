using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetShaderProperty : MonoBehaviour {

    public Material material;
    public string propertName;
    public Transform player;
	
	// Update is called once per frame
	void Update () {
		
        if(player != null)
        {
            material.SetVector(propertName, player.position);
        }
        else
        {
            Debug.Log("assign the player property");
        }
	}
}
