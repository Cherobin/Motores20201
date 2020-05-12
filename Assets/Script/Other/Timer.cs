using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float timer;
    private bool isStart;
    private float initValueTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        timer = initValueTimer;
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            timer -= Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isStart = true;
    }

    public void ResetTimer()
    {
        timer = initValueTimer;
        isStart = false;
    }

    public void PauseTimer()
    {
        isStart = !isStart;
    }

    public void setTimer(float time)
    {
        timer = initValueTimer = time;
    }

    public float getTimer()
    {
        return timer;
    }
}
