using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;

    PlayerBehaviourScript player;
  
    void Start()
    {
        if (score == null)
        {
            Debug.LogError(this.name + "Coin is null in ->>" + name);

        }

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviourScript>();

        if (player == null) {
            Debug.LogError(this.name + " Player is null in ->> " + name);
        }
    }

    void Update()
    {
        score.text = "Coin:: " + player.score;
    }
}
