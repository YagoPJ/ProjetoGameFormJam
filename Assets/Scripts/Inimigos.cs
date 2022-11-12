using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            PlayerController.pontos += 1;
        }
    }
}
