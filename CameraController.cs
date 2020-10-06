using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float lookSpeed;
    public float zoomSpeed;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        if (horizontal != 0)
        {
            gameObject.transform.Translate(Vector3.right * horizontal * moveSpeed * Time.deltaTime);
        }

        if (vertical != 0)
        {
            gameObject.transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        }

        if (Input.GetButton("RightClick"))
        {
            float mouseX = Input.GetAxis("Mouse X"); //rotation y
            float mouseY = Input.GetAxis("Mouse Y"); //rotation x

            if (mouseX != 0)
            {
                gameObject.transform.Rotate(Vector3.up * mouseX * lookSpeed * Time.deltaTime);
            }

            if (mouseY != 0)
            {
                gameObject.transform.Rotate(Vector3.right * mouseY * -lookSpeed * Time.deltaTime);
            }
        }

        if (scrollWheel != 0)
        {
            mainCamera.fieldOfView += -scrollWheel * zoomSpeed;
        }
    }
}
