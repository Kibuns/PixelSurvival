using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private PlayerControlls playerControlls;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlls.Player.Fire1.triggered)
        {
            Debug.Log("rotate");
            //rotate the roation.y of the gameObject by +90
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 45, transform.eulerAngles.z);
        }
    }

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable();
    }
}
