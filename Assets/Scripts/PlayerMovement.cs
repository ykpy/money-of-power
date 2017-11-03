using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    Rigidbody rb;

    [SerializeField]
    float moveSpeed;

    Animator animator;
    bool isWalking;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        var direction = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        rb.velocity = direction;


        if (Mathf.Abs(direction.x) > 0.2f || Mathf.Abs(direction.z) > 0.2f) {
            transform.localRotation = Quaternion.LookRotation(direction);
            isWalking = true;
        } else {
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);
    }
}