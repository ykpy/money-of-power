using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    Rigidbody rb;

    [SerializeField]
    float moveSpeed;
    bool isGrounded = true;

    Animator animator;

    CharacterController controller;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (isGrounded) {
            if (Input.GetButtonDown("Jump"))
            {
                var jumpPower = new Vector3(0, 6, 0);
                rb.velocity = jumpPower;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }
}
