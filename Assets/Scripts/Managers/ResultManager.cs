using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{

    PlayerStatus player1Status;
    PlayerStatus player2Status;
    PlayerStatus winner;
    PlayerStatus loser;
    AudioSource[] audioSources;
    Queue<AudioSource> audioQueue;
    int time;
    bool isDraw = false;

    public Text winnerName;
    public Text resultText;
    public GameObject explosion;


    // Use this for initialization
    void Start()
    {
        player1Status = GameManager.Instance.player1Status;
        player2Status = GameManager.Instance.player2Status;
        time = TimeManager.Instance.time;
        audioSources = gameObject.GetComponents<AudioSource>();
        audioQueue = new Queue<AudioSource>(audioSources);

        // 制限時間が残っていた場合
        if (time > 0)
        {
            if (player2Status.pride <= 0)
            {
                winner = player1Status;
                loser = player2Status;
            }
            else
            {
                winner = player2Status;
                loser = player1Status;
            }
        }
        // 制限時間に達した場合
        else
        {
            if (player1Status.money > player2Status.money)
            {
                winner = player1Status;
                loser = player2Status;
            }
            else if (player1Status.money < player2Status.money)
            {
                winner = player2Status;
                loser = player1Status;
            }
            // 所持金が同じ場合プライド残量で判定
            else
            {
                if (player1Status.pride > player2Status.pride)
                {
                    winner = player1Status;
                    loser = player2Status;
                }
                else if (player1Status.pride < player2Status.pride)
                {
                    winner = player2Status;
                    loser = player1Status;
                }
                else
                {
                    isDraw = true;
                }
            }
        }
        if (isDraw)
        {
            resultText.text = "引き分け";
            winnerName.text = "めずらしい。";
        }
        else
        {
            resultText.text = "勝者";
            winnerName.text = winner.gameObject.name;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            AudioSource currentSource = audioQueue.Dequeue();
            currentSource.Stop();
            currentSource.volume = 1f;
            currentSource.Play();
            foreach (AudioSource source in audioQueue)
            {
                source.volume = 0.9f * source.volume;
                Debug.Log(source.volume);
            }
            audioQueue.Enqueue(currentSource);

            Instantiate(explosion, loser.transform);
        }
    }
}
