using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaser : MonoBehaviour {

    public LineRenderer laserLine;
    public Transform laserPoint;
    public Light laserLight;
    public float fadeSpeed = 1;
    public float laserLength = 1000;

    Color laserColor;
    float lightIntensity;


	// Use this for initialization
	void Start () {
        laserColor = laserLine.material.GetColor("_TintColor");
        lightIntensity = laserLight.intensity;
        laserLine.SetPosition(1, Vector3.forward * laserLength);
        laserLine.useWorldSpace = true;
        laserLight.intensity = 0;
        laserLine.material.SetColor("_TintColor", Color.black);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }

        laserLine.material.SetColor("_TintColor", Color.Lerp(laserLine.material.GetColor("_TintColor"), Color.black, Time.deltaTime * fadeSpeed));
        laserLight.intensity = Mathf.Lerp(laserLight.intensity, 0, Time.deltaTime * fadeSpeed);
	}

    void Fire()
    {
        laserLine.material.SetColor("_TintColor", laserColor);
        laserLight.intensity = lightIntensity;

        laserLine.SetPosition(0, laserPoint.position);
        laserLine.SetPosition(1, laserPoint.position + laserPoint.TransformDirection(Vector3.forward * laserLength));
    }
}
