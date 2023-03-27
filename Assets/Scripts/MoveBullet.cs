using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Vector3 direction;
    public int speed;
    public float fadeInSeconds = 1;
    public float maxLifetime = 2;

    private float time = 0;
    private bool hasCollided = false;
    private float initialIntensity;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(direction * speed);
        light = gameObject.GetComponentInChildren<Light>();
        initialIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasCollided)
        {
            time += Time.deltaTime;
            light.intensity = (2 - (time / fadeInSeconds)*2) * initialIntensity;
            if(time > fadeInSeconds)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            time += Time.deltaTime;
            if(time > maxLifetime) { Destroy(gameObject); }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        time = 0;
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy hit!");
            //TODO: damage enemy
            

        }
        else
        {
            Debug.Log("something else hit!");
            //TODO: dirt splash when missing

        }
        EnterCollidedStage();

    }

    private void EnterCollidedStage()
    {
        hasCollided = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
