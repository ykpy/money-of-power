using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
    public Transform hand;
    BoxCollider bc;

    public int damage;
    public int jumpDamage;
    public PlayerMovement playerMovement;
    public PlayerJump pj;
    bool isCollisionDetection = false;
    // Use this for initialization
    void Start () {
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;
        this.gameObject.transform.SetParent(hand);
    }

    // Update is called once per frame
    void Update () {
        if (PlayerInput.GetButtonDown("Fire1", playerMovement.PlayerID) && bc.enabled == false) {
            bc.enabled = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        if (!other.gameObject.name.StartsWith("Player"))
        {
            return;
        }

        if (pj.GetIsGrounded()) {
            other.GetComponent<PlayerStatus>().calculateDamage(jumpDamage);
        } else {
            other.GetComponent<PlayerStatus>().calculateDamage(damage);
        }

        StartCoroutine(WaitAttack());
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(1f);
        bc.enabled = false;
   }
}
