using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoleHandler : MonoBehaviour
{
    public float speed;
    public FixedJoystick fixedJoystick;
    public Rigidbody rb;
    [SerializeField] private float maxVelocity;


    void Start()
    {
        
    }
    void Update()
    {

    }


    public void FixedUpdate()
    {
        if(!Touchscreen.current.primaryTouch.press.isPressed){Invoke("StopMoving", 0.15f);}
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        direction.y = 0f;
        direction.Normalize();
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }

    
}
