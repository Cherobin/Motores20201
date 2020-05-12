using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourScript : MonoBehaviour
{

    private GameObject player;
    public Vector3 offset;

    public Vector3 oldPosition;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player is Null in ->> " + name);

        } else { 
            offset = transform.position - player.transform.position;
        }

        oldPosition = transform.position;
    } 
 

    // Update is called once per frame
    void LateUpdate()
    {

        oldPosition = transform.position;

        transform.position = player.transform.position + offset;

    }
}
