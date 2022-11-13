using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    private bool colidiu;

    [SerializeField]
    GameController gameControll;
    // Start is called before the first frame update
    void Start()
    {
        colidiu = false;
        gameControll = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(GameController.speedEnemy, 0, 0);
        if(transform.position.x < -15.3f)
        {
            FindObjectOfType<PlayerController>().life -= 1;
            if (FindObjectOfType<PlayerController>().life == 0)
            {
                print("game over");
            }
            Destroy(gameObject);
        }

        if (colidiu == true)
        {
            Destroy(gameObject);
            PlayerController.pontos += 1;
            gameControll.SalvarScore();
        }

        if(FindObjectOfType<PlayerController>().canMove == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            colidiu = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerController>().life -= 1;
            Destroy(gameObject);
        }
    }
}
