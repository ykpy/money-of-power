using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

    public ParticleSystem particle;
    public PlayerMovement playerMovement;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerInput.GetButtonDown("Fire1", playerMovement.PlayerID))
        {
            if (playerMovement.PlayerID == PlayerInput.PlayerID.Player1)
            {
                Vector3 tmp = GameObject.Find("Player1").transform.position;
                GameObject.Find("skillAttack1").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
                particle = GameObject.Find("skillAttack1").GetComponent<ParticleSystem>();
            } 
            else
            {
                Vector3 tmp = GameObject.Find("Player2").transform.position;
                GameObject.Find("skillAttack2").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
                particle = GameObject.Find("skillAttack2").GetComponent<ParticleSystem>();
            }
            particle.Play();
        }
    }
}
