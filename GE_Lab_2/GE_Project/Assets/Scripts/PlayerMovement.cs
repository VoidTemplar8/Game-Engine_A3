using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static event Action jumpEvent;
    public float speedMultiplier = 5f;
    public float jumpForce = 10f;
    public float turnSpeed = 90f;
    float currentAngle;
    Rigidbody rb;
    Vector3 respawnPosition;

    bool isFalling = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        respawnPosition = transform.position;
    }
    //Used so that we can move in diagonals and combine movement and stuff like that
    Vector3 currentMovement;
    // Update is called once per frame
    void Update()
    {
        //Done this way to support diagonal movement
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
        //adjusting movement
        Vector3 move = new Vector3(currentMovement.x * speedMultiplier, rb.velocity.y, currentMovement.z * speedMultiplier); 
        move = Quaternion.AngleAxis(currentAngle, Vector3.up) * move; 
        rb.velocity = move;
        //Jumping
        if(Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpEvent?.Invoke();
            isFalling = true;
        }
        //TODO: player rotation which should rotate the camera as well
        if(Input.GetKey(KeyCode.Q))
        {
            transform.rotation *= Quaternion.AngleAxis(turnSpeed * Time.deltaTime, Vector3.up);
            currentAngle = transform.rotation.eulerAngles.y;
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.rotation *= Quaternion.AngleAxis(-turnSpeed * Time.deltaTime, Vector3.up);
            currentAngle = transform.rotation.eulerAngles.y;
        }
        if(transform.position.y < -50f)
        {
            transform.position = respawnPosition;
        }
    } 
    void OnCollisionStay()
    {
        isFalling = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Checkpoint")
        {
            Vector3 newPos = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y + 5, col.gameObject.transform.position.z);
            respawnPosition = newPos;
        }
    }
}
