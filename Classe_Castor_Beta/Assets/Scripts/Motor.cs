using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public VariableJoystick variableJoystick;

    private bool isRunning = false;
    private bool isThrowing = false;
    private bool isKissing = false;
    private bool isDancingSamba = false;
    private bool isDancingSalsa = false;
    private bool isDancingMaozinha = false;
    
    private Rigidbody rb;    
    private Animator anim;

    public Vector3 direction;

    public float jumpHeight = 3f;
    
    void Start () 
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        isRunning = false;

        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * moveSpeed);
        
        anim.SetBool("isRunning", isRunning);

        if (Input.GetKeyDown(KeyCode.Space))
        {
        transform.Translate(Vector3.up * jumpHeight);
        }
    }

}
