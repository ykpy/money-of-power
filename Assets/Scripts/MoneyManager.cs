using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyManager : MonoBehaviour {

    public Text money1;
    public Text money2;

    public PlayerStatus playerStatus1;
    public PlayerStatus playerStatus2;

    // Use this for initialization
    void Start () {
        money1 = GameObject.Find("MoneyPL1").GetComponent<Text>();
        money2 = GameObject.Find("MoneyPL2").GetComponent<Text>();

        playerStatus1 = GameManager.Instance.player1Status;
        playerStatus2 = GameManager.Instance.player2Status;
    }

    // Update is called once per frame
    void Update () {
        money1.text = string.Format("¥{0:#,0}", playerStatus1.money);
        money2.text = string.Format("¥{0:#,0}", playerStatus2.money);
    }
}
