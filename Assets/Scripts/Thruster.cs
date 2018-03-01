using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour {

    public LineRenderer thrusterLine;
    public Light thrusterLight;
    public float maxLenght = 10;
    [Range(0, 0.1f)]
    public float flickerAmount = 0.1f;
    public float flickerSpeed = 60;
    public bool velocityBasedLength = false;
    public float velocityModifier = 10;

    float lightIntensity;
    float speed;
    float length;
    Color thrusterColor;
    Vector3 position;

	// Use this for initialization
	void Start () {
        thrusterLine.SetPosition(1, Vector3.forward * length);
        thrusterColor = thrusterLine.material.GetColor("_TintColor");
        lightIntensity = thrusterLight.intensity;
        InvokeRepeating("Flicker", 0, 1 / flickerSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        length = maxLenght;
        if (velocityBasedLength)
        {
            ComputeThrusterLength();
            length = Mathf.Clamp(speed, 0, maxLenght);
        }
	}

    void Flicker()
    {
        float noise = Random.Range(1 - flickerAmount, 1);
        thrusterLine.material.SetColor("_TintColor", thrusterColor * noise);
        thrusterLine.SetPosition(1, Vector3.forward * length * noise);
        thrusterLight.intensity = noise * (Mathf.Clamp(length, 0, 8));
    }

    void ComputeThrusterLength()
    {
        speed = velocityModifier * (transform.position - position).magnitude;
        position = transform.position;
    }
}
