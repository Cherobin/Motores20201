using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviourScript : MonoBehaviour
{ 
    public int maxValueCoin = 1;
    public int valueCoin;

    // Start is called before the first frame update
    void Start()
    { 
        valueCoin = Random.Range(0, maxValueCoin);
    }
}
