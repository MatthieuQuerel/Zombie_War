using UnityEngine;  
public class MouvePlayer : MonoBehaviour
{
    public float speedPlayer = 50f;
    void Update()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");

        Vector3 move = transform.right * axisH + transform.forward * axisV;
        
       
        transform.position += move * speedPlayer * Time.deltaTime;

    }
}