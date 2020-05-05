using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{

    public GameObject coin;
    public GameObject mainCoin;

    // Start is called before the first frame update
    void Awake()
    {
        if (coin == null)
        {
            Debug.LogError("Prefab da coin is null");
        } else
        { 
            for (int i = 0; i < 100000; i++) {
                coin.name = "Coin " + i;
                Instantiate(coin, new Vector3(i * 20.0F, 0, 0), Quaternion.identity, mainCoin.transform);
            }
        }
    }
}
