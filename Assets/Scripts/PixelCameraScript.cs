using UnityEngine;
using Cinemachine;

public class PixelCameraScript : MonoBehaviour
{
    public float pixelsPerUnit = 32f;
    public Camera mainCamera;
    public Transform followObject;

    public float rotationSpeed = 1f;
    private float distance;
    private float height;

    //private CinemachineVirtualCamera _camera;

    private void Start()
    {
        distance = Vector3.Distance(gameObject.transform.position, followObject.transform.position);
        height = transform.position.y - followObject.position.y;
    }

    private void Update()
    {
        //PIVOT MECHANICS
        // Calculate the pivot point position based on the followObject's position and rotation
        Vector3 pivotPoint = followObject.position;

        // Calculate the target position based on the pivot point, distance, and height
        Vector3 targetPosition = pivotPoint - followObject.forward * distance;

        // Move the gameObject to the target position
        transform.position = targetPosition;

        // Calculate the target rotation based on the direction from the gameObject to the pivot point
        Vector3 lookDirection = pivotPoint - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        // Apply the target rotation to the gameObject with rotation speed
        transform.rotation = followObject.rotation;

   




        // Calculate the position of the canvas camera in world space
        Vector3 cameraPosition = transform.position;

        // Calculate the position of the canvas camera in screen space
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(cameraPosition);


        // Round the screen space position to the nearest pixel
        Vector3 roundedScreenPosition = new Vector3(
            Mathf.RoundToInt(screenPosition.x),
            Mathf.RoundToInt(screenPosition.y),
            screenPosition.z
        );

        // Convert the rounded screen space position back to world space
        Vector3 roundedCameraPosition = mainCamera.ScreenToWorldPoint(roundedScreenPosition);

        // Snap the canvas camera to the rounded position
        transform.position = roundedCameraPosition;

        // Adjust the orthographic size to maintain the desired pixels per unit
        //_camera.m_Lens.OrthographicSize = Screen.height / (2 * pixelsPerUnit);
    }

    private void LateUpdate()
    {

    }
}
