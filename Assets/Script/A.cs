using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class A : MonoBehaviour
{
    private Rigidbody rb;
    private bool setti;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0,0,0.2f);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position += new Vector3(0,0,-0.2f);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-0.2f, 0,0);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }
        if (setti && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
            setti = false; 
        }

        if (transform.position.y <= -2)
        {
            transform.position = new Vector3(0, 2.0f, 0);
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("yuka"))
        {
            setti = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("yuka"))
        {
            setti = false;
        }
    }
}