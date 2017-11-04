using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PrideBarManager : MonoBehaviour {

	Slider slider1;
    Slider slider2;

    public PlayerStatus playerStatus1;
    public PlayerStatus playerStatus2;

    // Use this for initialization
    void Start () {
        slider1 = GameObject.Find("PridePL1").GetComponent<Slider>();
        slider2 = GameObject.Find("PridePL2").GetComponent<Slider>();

        playerStatus1 = GameManager.Instance.player1Status;
        playerStatus2 = GameManager.Instance.player2Status;
    }

	// Update is called once per frame
	void Update () {
		slider1.value = playerStatus1.pride / 100f;
        slider2.value = playerStatus2.pride / 100f;
    }
}
