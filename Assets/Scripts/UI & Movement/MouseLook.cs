/*Author: Christian Cerezo */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivityX = 200f;
    [SerializeField] float mouseSensitivityY = 200f;
    Camera cam;
    float verticalRotation;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //getting the input of mouse delta
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * Time.deltaTime;

        //creating another float variable to clamp it later
        verticalRotation -= mouseInput.y * mouseSensitivityY;

        //clamping verticalRotation
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        //setting the localRotation of the camera
        cam.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //horizontal rotation of player along with camera.
        transform.Rotate(Vector3.up * mouseInput.x * mouseSensitivityX);
    }
}