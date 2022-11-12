using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{

    public float speed;
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
        transform.position -= new Vector3(speed, 0, 0);
        if(transform.position.x < -11.5f)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            colidiu = true;
        }
    }
}
