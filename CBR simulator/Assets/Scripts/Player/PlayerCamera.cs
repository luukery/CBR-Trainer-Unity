using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The camera will be controlled by the vr headset in the future. This camera is just for the prototype
//https://www.youtube.com/watch?v=_QajrabyTJc&t=168s 
public class PlayerCamera : MonoBehaviour
{
    float mouseSensitivty = 200;
    Transform playerTransform;
    float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = transform.parent.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
