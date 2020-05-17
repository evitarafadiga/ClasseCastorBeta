using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{

    public float moveSpeed = 15.0f;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    private Vector3 direction;

    private void FixedUpdate()
    {
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * moveSpeed);
    }
}
