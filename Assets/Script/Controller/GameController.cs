using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{


    public TextMeshProUGUI textTimer;

    private float timeScale;
    private Timer myTimer;
    static public bool isPause;

    void Start()
    {
        isPause = false;

        timeScale = Time.timeScale;
         
        if (textTimer == null)
        {
            Debug.Log("textTimer is null in ->" + name);
        }

        myTimer = GetComponent<Timer>();

        if (myTimer == null)
        {
            Debug.Log("time is null in ->" + name);
        }
    }

    private void Update()
    {
        textTimer.text = "Timer :: " + myTimer.timer;
    } 

    public void StartGame()
    {
        myTimer.StartTimer();
        Time.timeScale = timeScale;
        isPause = false;
    }

    public void ResetGame()
    {

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pick Up"))
        {
            Destroy(obj);
        }

        myTimer.ResetTimer();  
        Time.timeScale = timeScale;
        isPause = true;
    }


    public void PauseGame()
    {
        myTimer.PauseTimer();
        Time.timeScale = 0;
        isPause = true;
    }
}
