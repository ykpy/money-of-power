using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrideBarManager : MonoBehaviour {

	public Slider slider;
	float pride = 1;

	// Use this for initialization
	void Start () {
//		slider = GameObject.Find ("PridePL2").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pride > 0) {
			pride -= 0.01f;
		}
		slider.value = pride;
	}
}
