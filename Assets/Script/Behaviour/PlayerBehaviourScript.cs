using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerBehaviourScript : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    public int score;
    public string namePlayer;
    public TextMeshProUGUI namePlayerGUI;
    public TMP_InputField inputNamePlayerGUI;
    

    void Start()
    {

        namePlayer = "";

        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody is null in ->> " + name);
        }

        if (namePlayerGUI == null)
        {
            Debug.LogError("namePlayerGUI is null in ->> " + name);
        }

        if (inputNamePlayerGUI == null)
        {
            Debug.LogError("inputNamePlayerGUI is null in ->> " + name);
        }

//        PlayerPrefs.DeleteAll();

        inputNamePlayerGUI.enabled = false;
        

        namePlayerGUI.text = namePlayer;
        score = 0;

        loadInfo();

       
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(move * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up") && !GameController.isPlayerOne) {
            score += other.gameObject.GetComponent<CoinBehaviourScript>().valueCoin;
            Destroy(other.gameObject); 
        }
    }


    public void saveInfo()
    {
       

        namePlayerGUI.text = inputNamePlayerGUI.text;

        int oldScore = PlayerPrefs.GetInt("my_score");
        if(score > oldScore)
        {
            PlayerPrefs.SetInt("my_score", score);
            inputNamePlayerGUI.enabled = true;

            EventSystem.current.SetSelectedGameObject(inputNamePlayerGUI.gameObject, null);
            
        }

        PlayerPrefs.SetFloat("timer", 0.7f);
        PlayerPrefs.SetString("jogador", inputNamePlayerGUI.text);

        // PlayerPrefs.SetInt("my_score", 0);


        PlayerPrefs.Save();
    }

    public void loadInfo()
    {
        if (PlayerPrefs.HasKey("my_score")) {
            score = PlayerPrefs.GetInt("my_score");
        }

        if (PlayerPrefs.HasKey("timer"))
        {
            float timer = PlayerPrefs.GetFloat("timer");
        }

        if (PlayerPrefs.HasKey("jogador"))
        {
            namePlayer = PlayerPrefs.GetString("jogador");
            namePlayerGUI.text = namePlayer;
        }
    }

    public void nextScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
       // SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetSceneByName(name));
        
    }
}




