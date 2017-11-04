using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : SingletonMonoBehaviour<TimeManager> {

	public int time;
	float times;
	Text timeText;
    bool isTimeUp = false;

    // Use this for initialization
    void Start () {
		timeText = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (time > 0) {
            times -= Time.deltaTime;
            if (times <= 0.0) {
                times = 1.0f;
                time--;
            }
            timeText.text = time.ToString();
        } else {
            if (!isTimeUp) {
                TimeUp();
                isTimeUp = true;
            }
        }
	}

    void TimeUp()
    {
        Debug.Log("Time Up!!");
        GameManager.Instance.FinishGame();
    }
}
