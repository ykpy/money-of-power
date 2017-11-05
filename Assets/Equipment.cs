using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
    public Transform hand;
    BoxCollider bc;

    public int damage;
    public int jumpDamage;
    public int pay;
    public int jumpPay;
    public int loseMoney;
    public PlayerStatus myPs;
    public PlayerMovement playerMovement;
    public PlayerJump pj;
    bool isCollisionDetection = false;

    [SerializeField]
    AudioClip hitSE;
    [SerializeField]
    AudioClip resisterSE;
    [SerializeField]
    AudioClip laughSE;
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        bc = GetComponent<BoxCollider>();
        bc.enabled = false;
        this.gameObject.transform.parent.SetParent(hand);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (PlayerInput.GetButtonDown("Fire1", playerMovement.PlayerID) && bc.enabled == false) {
            Debug.Log("Attack");
            bc.enabled = true;
            Vector3 pos = this.gameObject.transform.localPosition;
            pos.x *= -2;
            pos.y *= 11;
            pos.z *= 7;
            this.gameObject.transform.localPosition = pos;
            gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x * 10,
            gameObject.transform.localScale.y * 10,
            gameObject.transform.localScale.z * 10
                );
            StartCoroutine(WaitAttack());
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
            other.GetComponent<PlayerStatus>().CalculateDamage(damage);
            other.GetComponent<PlayerStatus>().PlusMoney(pay, myPs.money);
            myPs.MinusMoney(pay);

        }
        else {
            other.GetComponent<PlayerStatus>().CalculateDamage(jumpDamage);
            other.GetComponent<PlayerStatus>().PlusMoney(jumpPay, myPs.money);
            myPs.MinusMoney(jumpPay);
        }
        audioSource.PlayOneShot(hitSE);
        audioSource.PlayOneShot(resisterSE);
        bc.enabled = false;
        Vector3 pos = this.gameObject.transform.localPosition;
        pos.x /= -2;
        pos.y /= 11;
        pos.z /= 7;
        this.gameObject.transform.localPosition = pos;
        gameObject.transform.localScale = new Vector3(
        gameObject.transform.localScale.x / 10,
        gameObject.transform.localScale.y / 10,
        gameObject.transform.localScale.z / 10
            );
    }

    IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(1f);
        if (bc.enabled == true) {
            audioSource.PlayOneShot(laughSE);
            bc.enabled = false;
            Vector3 pos = this.gameObject.transform.localPosition;
            pos.x /= -2;
            pos.y /= 11;
            pos.z /= 7;
            this.gameObject.transform.localPosition = pos;
            gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x / 10,
            gameObject.transform.localScale.y / 10,
            gameObject.transform.localScale.z / 10
                );
            myPs.MinusMoney(loseMoney);
        }
    }

}
