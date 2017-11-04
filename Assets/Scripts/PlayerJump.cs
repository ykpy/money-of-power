using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(AudioSource))]
public class PlayerJump : MonoBehaviour {

    Rigidbody rb;

    [SerializeField]
    float jumpPower;
    bool isGrounded = true;

    PlayerMovement playerMovement;

    [SerializeField]
    AudioClip jumpSE;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (isGrounded) {
            if (PlayerInput.GetButtonDown("Jump", playerMovement.PlayerID))
            {
                rb.velocity = new Vector3(0, jumpPower, 0);
                // 効果音の再生
                audioSource.PlayOneShot(jumpSE);
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

    public bool GetIsGrounded() {
        return isGrounded;
    }
}
