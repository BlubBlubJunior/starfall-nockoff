using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float movementspeed;

    [SerializeField] private float jumpforce;

    public bool isGrounded;
    
    public LayerMask layer;
        
    private Rigidbody rb;
    private Vector3 movementInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        movementInput = new Vector3(horizontalInput, 0f, 0f);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }

        rb.velocity = movementInput * movementspeed + new Vector3(0f, rb.velocity.y, 0f);
        
        //anime.SetFloat("sidemovement", horizontalInput);
        
        
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
    
    
}
