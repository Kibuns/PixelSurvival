using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Camera cam;
    RaycastHit hit;
    Ray ray;
    public LayerMask mask;
    public float maxDistance = 500;

    void Start()
    {
        //cam = GameObject.Find("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, maxDistance, mask))
        {
            transform.position = hit.point;
        }
    }
}
