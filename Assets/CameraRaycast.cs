using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour {

    public Transform lightHit;
    public Material mat;
    public string propertName;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (lightHit != null)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out hit);

            lightHit.position = hit.point;

            mat.SetVector(propertName, lightHit.position);

            //Debug.Log("x: " + lightHit.position.x + ", y: " + lightHit.position.y + ", z: " + lightHit.position.z);

        }
    }
}
