using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    Rigidbody rb;

    [SerializeField]
    float jumpPower;
    bool isGrounded = true;

    Animator animator;

    CharacterController controller;
    PlayerMovement playerMovement;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update () {
        if (isGrounded) {
            if (PlayerInput.GetButtonDown("Jump", playerMovement.PlayerID))
            {
                rb.velocity = new Vector3(0, jumpPower, 0);
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
