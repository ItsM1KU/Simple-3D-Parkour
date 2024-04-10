using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpSpeed = 5.0f;
    [SerializeField] float gravitychange = -2.0f;

    private bool isGrounded;
    float moveside;
    float movefront;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveside = Input.GetAxis("Horizontal");
        movefront = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveside, 0, movefront);
        moveDirection.Normalize();
        transform.Translate(moveDirection * speed * Time.deltaTime);

         
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }

        if(!isGrounded)
        {
            rb.velocity += Vector3.down * gravitychange * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
