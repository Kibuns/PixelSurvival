using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCube : MonoBehaviour
{
    public float rpm = 60;
    public bool clockwise = true;
    public float amplitude = 0.5f; // the amplitude of the sine wave
    public float frequency = 1f; // the frequency of the sine wave

    private Vector3 startPosition; // the starting position of the gameobject
    void Start()
    {
        startPosition = transform.position; // save the starting position
    }


    void Update()
    {
        float amount = ((Time.deltaTime * rpm)*60) / 10;
        if (!clockwise) { amount *= -1; }
        gameObject.transform.Rotate(new Vector3(0, amount, 0));

        // use the sine function to calculate the y position
        float newY = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency);

        // update the gameobject's position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
