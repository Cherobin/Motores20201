using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class UtilsScript : MonoBehaviour
{

    //GameObject
    public GameObject mainCoin;

    public float timeStart;
    public float timeEnd;
    public float diffTime;

    // Start is called before the first frame update
    void Start()
    {

        timeStart = System.DateTime.Now.Millisecond;

        //getObject();// 41 mls

        //getTags(); //18 mls

        //refObject(); //932 mls

        //100000 mil objetos

        timeEnd = System.DateTime.Now.Millisecond;

        diffTime = timeEnd - timeStart;

        Debug.Log("timeStart" + timeStart);
        Debug.Log("timeEnd" + timeEnd);

        Debug.Log("diffTime" + diffTime);
    }

    void getObject()
    {

        Object[] objects = FindObjectsOfType<GameObject>();

        //Debug.Log(objects.Length);
        /*
        for (int i = 0; i < objects.Length; i++)
        {
           // Debug.Log(((GameObject)objects[i]).CompareTag("Pick Up"));
            if (((GameObject)objects[i]).CompareTag("Pick Up"))
            {
            //    Destroy(objects[i]);
            }

        }  
        */
    }

    //com tag
    void getTags()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Pick Up");
      //  Debug.Log("Com tag" + coins.Length);

        /*
        for (int i = 0; i < coins.Length; i++)
        {
            //coins[i].name = "Coin com tag" + i;
        }
        */

    }


    //com ref do objecto
    void refObject()
    {
        /*
        if (mainCoin == null)
        {
            Debug.LogError("MainCoin prefab is null");

        }
        */
        // Debug.Log(mainCoin.transform.childCount);

        List<GameObject> lista = new List<GameObject>();
         
        for (int i = 0; i < mainCoin.transform.childCount; i++)
        {
            lista.Add(mainCoin.transform.GetChild(i).gameObject);
            //mainCoin.transform.GetChild(i).name = "Coin " + i;
        }
      
    }
}
