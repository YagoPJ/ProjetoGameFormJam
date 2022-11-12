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
        if (transform.position.x < -11.5f)
        {
            Destroy(gameObject);
        }

        if (colidiu == true)
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
            print("buff tipo1");
        }
        if (buffsType == 2)
        {
            print("buff tipo2");
        }
        if (buffsType == 3)
        {
            print("buff tipo3");
        }
        if (buffsType == 4)
        {
            print("buff tipo4");
        }
    }
}
