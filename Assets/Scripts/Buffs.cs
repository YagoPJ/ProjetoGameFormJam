using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public float speed;
    private bool colidiu;
    private int buffsType;
    // Start is called before the first frame update
    void Start()
    {
        colidiu = false;
        buffsType = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(speed, 0, 0);
        if (transform.position.x < -15.3f)
        {
            Destroy(gameObject);
        }

        if (colidiu == true)
        {
            Destroy(gameObject);
        }

        if (FindObjectOfType<PlayerController>().canMove == false)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            colidiu = true;
            BuffsValues();
        }
    }

    void BuffsValues()
    {
        if(buffsType == 1)
        {
            if(PlayerController.speedNave < 0.2f)
            {
                print("buff tipo1");
                PlayerController.speedNave += 0.009f;
            } 
        }
        if (buffsType == 2)
        {
            if(PlayerController.timeBullet > 0.1f)
            {
                print("buff tipo2");
                PlayerController.timeBullet -= 0.07f;
            }
        }
    }
}
