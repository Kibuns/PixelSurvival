using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{
    public Transform obj;

    [Tooltip("Select which dimensions of obj should be copied to the transform of the gameObject")]
    [Header("Dimensions to copy")]

    public bool X;
    public bool Y;
    public bool Z;

    void Update()
    {
        float x = X ? obj.position.x : transform.position.x;
        float y = Y ? obj.position.y : transform.position.y;
        float z = Z ? obj.position.z : transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
