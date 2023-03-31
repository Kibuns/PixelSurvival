using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    [SerializeField]
    public GameObject target;
    private Vector3 point;
    public float speed = 10;

    private void Update()
    {
        point = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);


        Vector3 direction = (point - transform.position).normalized;
        Debug.DrawRay(transform.position, direction);
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        

        transform.LookAt(point);
    }
}
