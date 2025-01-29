using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public bool isGrounded;
    public float dashCooldown = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckFloor();
        Jump();
        Dash();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();
    }
    void Moving()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + move * speed * Time.deltaTime);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldown <= 0 && !gameObject.GetComponent<Player>().isBlocking)
        {
            //check if moving
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                speed *= 5;
                dashCooldown = 3;
                StartCoroutine(DeactivateDash());
            }
            if (dashCooldown > 0)
            {
                dashCooldown -= Time.deltaTime;
            }
        }
    }
    IEnumerator DeactivateDash()
    {
        yield return new WaitForSeconds(0.1f);
        speed /= 5;
    }
    void CheckFloor()
    {
        float y = rb.velocity.y;
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f) && y == 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}