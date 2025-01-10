using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float camX;
    public bool isLeftHanded;
    bool isLocked = true;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        camX = transform.localPosition.x;
        isLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftHanded)
        {
            transform.localPosition = new Vector3(-camX, transform.localPosition.y, transform.localPosition.z);
        }
        else
        {
            transform.localPosition = new Vector3(camX, transform.localPosition.y, transform.localPosition.z);
        }
        CamMoving();
    }
    void CamMoving()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            player.Rotate(Vector3.up * inputX);
        }
    }
}
