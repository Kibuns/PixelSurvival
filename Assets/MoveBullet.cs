using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public Vector3 direction;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(direction * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy hit!");
            //TODO: damage enemy
            

        }
        else
        {
            Debug.Log("something else hit!");
            //TODO: dirt splash when missing

        }
        Destroy(gameObject);
    }
}
