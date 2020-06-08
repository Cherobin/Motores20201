using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{


    public TextMeshProUGUI textTimer;
    public TextMeshProUGUI textPlayer;
    public TextMeshProUGUI textStatusGame;
    private float timeScale;
    private Timer myTimer;
    static public bool isPause;
    static public bool isPlayerOne;

    public float timerPlayerOne = 15;
    public float timerPlayerTwo = 60;

    private GameObject mainCoin;

    public GameObject player;

    public int roundGame;

    void Start()
    {
        roundGame = 1;
        isPlayerOne = true;
        isPause = true;
        timeScale = Time.timeScale;

        if (textTimer == null)
        {
            Debug.Log("textTimer is null in ->" + name);
        }

        myTimer = GetComponent<Timer>();

        myTimer.setTimer(timerPlayerOne);

        mainCoin = GetComponent<ClickController>().objectCoins;

        if (myTimer == null)
        {
            Debug.Log("myTimer is null in ->" + name);
        }

        if (textPlayer == null)
        {
            Debug.Log("textTimer is null in ->" + name);
        }

        if (textPlayer == null)
        {
            Debug.Log("textPlayer is null in ->" + name);
        }

        if (textStatusGame == null)
        {
            Debug.Log("textStatusGame is null in ->" + name);
        }

        if (player == null)
        {
            Debug.Log("player is null in ->" + name);
        }

        
        PauseGame();
    }

    private void Update()
    {
        // textTimer.text = "Timer :: " + (int) myTimer.getTimer();

        textTimer.text = string.Format("Timer:: {0:F2}", myTimer.getTimer());

        textPlayer.text = "Player " + (isPlayerOne ? "1" : "2");

        if (myTimer.getTimer() <= 0 && !isPause) {
            changePlayer();
            roundGame++;
        }

        if (roundGame == 3)
        {
            setWinner();
        }
    }

    public void setWinner()
    {
        if (mainCoin.transform.childCount == 0)
        {
            textStatusGame.text = " Player 2 Wins!";
        }
        else 
        {
            textStatusGame.text = " Player 1 Wins!";
        }

        roundGame = 1;
        ResetGame();
        player.GetComponent<PlayerBehaviourScript>().saveInfo();
    }



    public void changePlayer()
    {
        PauseGame();
        isPlayerOne = !isPlayerOne;
        myTimer.setTimer(isPlayerOne ? timerPlayerOne : timerPlayerTwo);
    }


    public void StartGame()
    {
        myTimer.StartTimer();
        Time.timeScale = timeScale;
        player.GetComponent<PlayerBehaviourScript>().score = 0;
        isPause = false;
        textStatusGame.text = "";
    }

    public void ResetGame()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pick Up"))
        {
            Destroy(obj);
        }
    }


    public void PauseGame()
    {
        myTimer.PauseTimer();
        Time.timeScale = 0;
        isPause = true;
    }
}
