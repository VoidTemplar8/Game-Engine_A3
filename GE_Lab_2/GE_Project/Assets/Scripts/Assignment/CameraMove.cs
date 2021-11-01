using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 45f;
    float  currentAngle; 
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.rotation.eulerAngles.y;
    }
    // Update is called once per frame
    Vector3 currentMovement;
    void Update()
    {
        currentMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            currentMovement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentMovement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentMovement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentMovement += Vector3.right;
        }  
        if (Input.GetKey(KeyCode.Space))
        {
            currentMovement += Vector3.up;
        }
           if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMovement += Vector3.down;
        }      
        if(Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= Quaternion.AngleAxis(-turnSpeed * Time.deltaTime, Vector3.up);
            currentAngle = transform.rotation.eulerAngles.y;
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.rotation *= Quaternion.AngleAxis(turnSpeed * Time.deltaTime, Vector3.up);
            currentAngle = transform.rotation.eulerAngles.y;
        }
        //adjusting movement
        currentMovement = Quaternion.AngleAxis(currentAngle, Vector3.up) * currentMovement; 
        this.transform.position += currentMovement * Time.deltaTime * speed;
    }
}
