using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _startPosition;
    private bool _isGrounded;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0)
        {
            transform.position += direction * Time.deltaTime;
        }
    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
        
        if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal!");
        }
        
        if (other.gameObject.CompareTag("Lava"))
        {
            transform.position = _startPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
