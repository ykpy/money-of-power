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

    [SerializeField]
    PlayerInput.PlayerID playerId;
    public PlayerInput.PlayerID PlayerID {
        get { return playerId; }
    }

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Damaged@loop 0")) {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            return;
        }

        var cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        //var direction = new Vector3(PlayerInput.GetAxis("Horizontal", playerId) * moveSpeed, rb.velocity.y, PlayerInput.GetAxis("Vertical", playerId) * moveSpeed);
        var moveForward = cameraForward * PlayerInput.GetAxis("Vertical", playerId) + Camera.main.transform.right * PlayerInput.GetAxis("Horizontal", playerId);
        var direction = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);
        rb.velocity = direction;

        if (Mathf.Abs(direction.x) > 0.2f || Mathf.Abs(direction.z) > 0.2f) {
            transform.localRotation = Quaternion.LookRotation(moveForward);
            isWalking = true;
        } else {
            isWalking = false;
        }

        animator.SetBool("isWalking", isWalking);
    }

    public void Damage() {
        animator.SetTrigger("damage");
    }
}