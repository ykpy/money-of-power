using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipment : MonoBehaviour {
    public Transform hand;
	// Use this for initialization
	void Start () {
        this.gameObject.transform.SetParent(hand);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
