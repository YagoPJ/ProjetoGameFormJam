using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text pontosMax;
    public TextMeshProUGUI pontosTxt;
    public GameObject sobreTxt;
    public GameObject painelPause;
    public GameObject painelSobre;
    public bool pauseOn = false;
    public PlayerController pC;
    public static int pontosRank;
    public static float speedEnemy = 0.01f;
    public GameObject gameOverPanel;
    public GameObject fadePanel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController pC = gameObject.GetComponent<PlayerController>();
        pontosRank = PlayerPrefs.GetInt("scorePrefs");
        InvokeRepeating("AumentarVelocidade", 0, 10f);
        pontosTxt.text = "Maximo de pontos obtidos: " + pontosRank;
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
            pontosMax.text = "Maximo de pontos obtidos: " + pontosRank;
        }
        if (pauseOn == false)
        {
            //Time.timeScale = 1;
            painelPause.SetActive(false);
        }
        //Debug.Log(Time.timeScale);

        GameOver();
    }

    public void SalvarScore()
    {
        if(PlayerController.pontos > pontosRank)
        {
            pontosRank = PlayerController.pontos;
            PlayerPrefs.SetInt("scorePrefs", pontosRank);
        }
    }

    void AumentarVelocidade()
    {
        speedEnemy += 0.006f;
        //ScrollingSkyBox.rotateSpeed += 5f;
        Debug.Log(speedEnemy);
    }
    void GameOver()
    {
        if (pC.life == 0)
        {
            pC.canMove = false;
            gameOverPanel.SetActive(true);
            painelSobre.SetActive(false);
            fadePanel.SetActive(false);
            sobreTxt.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
        print("aperto");
    }
}
