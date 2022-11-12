using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text pontosMax;
    public GameObject painelPause;
    public bool pauseOn = false;
    public PlayerController pC;
    public static int pontosRank;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController pC = gameObject.GetComponent<PlayerController>();
        pontosRank = PlayerPrefs.GetInt("scorePrefs");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseOn = !pauseOn;
        }
        if(pauseOn == true)
        {
            //Time.timeScale = 0;
            painelPause.SetActive(true);
            pontosMax.text = "A pontuação máxima atualmente é: " + pontosRank;
        }
        if (pauseOn == false)
        {
            //Time.timeScale = 1;
            painelPause.SetActive(false);
        }
        //Debug.Log(Time.timeScale);
    }

    public void SalvarScore()
    {
        if(PlayerController.pontos > pontosRank)
        {
            pontosRank = PlayerController.pontos;
            PlayerPrefs.SetInt("scorePrefs", pontosRank);
        }
    }
}
