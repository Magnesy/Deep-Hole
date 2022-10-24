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

    //Gravity
    [Header("Gravity")]

    [Range(0f,400f)] public float power = 1f;
    [Range(-5f,4f)] public float upOrDown;
    [Range(0f,5f)] public float forceRange = 1f;
    public ForceMode forceMode;
    public LayerMask layerMask;
    public float maxRadius = 10f;


    void Start()
    {
        
    }
    void Update()
    {

    }


    private void FixedUpdate()
    {
        if(!Touchscreen.current.primaryTouch.press.isPressed){Invoke("StopMoving", 0.15f);}
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        direction.y = 0f;
        direction.Normalize();
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        Gravity(transform.position, forceRange, layerMask);
        
        //circle restriction
        var allowedPos = transform.position - new Vector3(0,0,0);
        allowedPos = Vector3.ClampMagnitude(allowedPos, maxRadius); 
        transform.position = new Vector3(0,0,0) + allowedPos;
    }

    public void StopMoving()
    {
        rb.velocity = Vector3.zero;
    }

    // void OnTriggerEnter(Collider other) {
    // if(other.gameObject.tag == "Objects"){other.GetComponent<Rigidbody>().isKinematic = false;}
    // }


    private void Gravity(Vector3 gravitySource, float range, LayerMask layerMask)
    {
        Collider[] objs = Physics.OverlapSphere(gravitySource, range , layerMask);

        for(int i = 0; i < objs.Length; i++)
        {
            Rigidbody rbs = objs[i].GetComponent<Rigidbody>();

            Vector3 forceDirection = new Vector3(gravitySource.x, upOrDown, gravitySource.z) - objs[i].transform.position;

            rbs.AddForceAtPosition(power * forceDirection.normalized, gravitySource);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,forceRange);
    }

}

