using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public int time;
	float times;
	Text timeText;

	// Use this for initialization
	void Start () {
		timeText = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		times -= Time.deltaTime;
		if (times <= 0.0) {
			times = 1.0f;
			time--;
		}
		timeText.text = time.ToString();
	}
}
