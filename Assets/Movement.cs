using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizantalInput;
    float verticalInput;
    [Range(0,500)]
    public float speed;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    private void Update()
    {
        horizantalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
;    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizantalInput * speed, rb.velocity.y, verticalInput * speed);
    }
}
