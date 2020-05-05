using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timer;
    public bool isStart;
    public float initValueTimer = 30;

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
}
