using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private PlayerControlls playerControlls;

    [SerializeField] private float rotationDuration = 0.2f; // Duration of the rotation in seconds
    private List<int> values = new List<int> { 45, 135, 225, 315 };
    private int currentIndex = 0;
    private int selectedValue = 45;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
    }

    // Update is called once per frame
    void Update()
    {

        // increment the index and wrap around to 0 if we reach the end of the list
        
        if (playerControlls.Player.E.triggered)
        {
            currentIndex = (currentIndex + 1) % values.Count;
            Debug.Log(currentIndex);
            selectedValue = values[currentIndex];
            StartCoroutine(RotateCamera(Quaternion.Euler(transform.eulerAngles.x, selectedValue, transform.eulerAngles.z))); // Start coroutine to rotate camera by 45 degrees
        }
        if (playerControlls.Player.Q.triggered)
        {
            currentIndex = (currentIndex - 1 + values.Count) % values.Count;
            Debug.Log(currentIndex);
            selectedValue = values[currentIndex];
            StartCoroutine(RotateCamera(Quaternion.Euler(transform.eulerAngles.x, selectedValue, transform.eulerAngles.z))); // Start coroutine to rotate camera by 45 degrees
        }
    }

    private IEnumerator RotateCamera(Quaternion targetRotation)
    {
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0;

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, (elapsedTime / rotationDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure final rotation is exact
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