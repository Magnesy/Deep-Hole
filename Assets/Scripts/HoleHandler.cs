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
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        direction.y = 0f;
        direction.Normalize();
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
