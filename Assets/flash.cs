using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    private int counter = 0;
    public int visibleFrames = 0;
    // Update is called once per frame

    void Update()
    {
        counter++;
        if(counter > visibleFrames) { Destroy(gameObject); }
    }
}
