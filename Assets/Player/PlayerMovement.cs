using UnityEngine;
using System.Collections;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class PlayerMovement : MonoBehaviour
{
    public float mouseSensitivity;   
    public float verticalSpeed;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        transform.position = new Vector3(0, 5, 0);

    }


    void Update()
    {
        //float h = horizontalSpeed * Input.GetAxis("Mouse X");
        //float v = verticalSpeed * Input.GetAxis("Mouse Y");

        //transform.Rotate(0, h, 0);
        float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivity * Time.deltaTime);
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivity * Time.deltaTime);
        Vector3 eulerRotation = transform.eulerAngles;

    }
}