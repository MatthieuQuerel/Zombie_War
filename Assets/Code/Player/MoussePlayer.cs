using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float mouseSensi = 200f;
    float Rotation = 0f;
    public Transform playerBody;

    void Start()
    {
        Demarage();
    }
    void Demarage()
    {
        if (playerBody == null)
    {
        playerBody = transform.parent;
    }
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
      
    float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

    
    Rotation -= mouseY;
    Rotation = Mathf.Clamp(Rotation, -90f, 90f);
    transform.localRotation = Quaternion.Euler(Rotation, 0f, 0f);


    playerBody.Rotate(Vector3.up * mouseX);
    

    }
}