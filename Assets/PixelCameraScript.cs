using UnityEngine;
using Cinemachine;

public class PixelCameraScript : MonoBehaviour
{
    public float pixelsPerUnit = 32f;
    public Camera mainCamera;
    public Transform player;
    public Vector3 vec;

    //private CinemachineVirtualCamera _camera;

    private void Start()
    {
        //_camera = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(-11, 14.8f, -11);
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
        Debug.Log(roundedScreenPosition);

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
