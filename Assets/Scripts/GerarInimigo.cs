using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarInimigo : MonoBehaviour
{
    public GameObject[] listaInimigo;
    //public Inimigos inimigo;
    public bool criar = true;
    public float timeCreate;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject inimigosLista = listaInimigo[Random.Range(0, listaInimigo.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        if(criar == true)
        {
            criar = false;
            StartCoroutine(criarInimigo());
        }
    }

    IEnumerator criarInimigo()
    {
        GameObject inimigosLista = listaInimigo[Random.Range(0, listaInimigo.Length - 1)];
        yield return new WaitForSeconds(timeCreate);
        criar = true;
        float y = Random.Range(-3.6f, 5.5f);
        float speed = Random.Range(0.01f, 0.05f);
        Inimigos inim = Instantiate(inimigosLista, transform.position + new Vector3(0, y, 0), transform.rotation = Quaternion.Euler(180, 90, -90)).GetComponent<Inimigos>();
        inim.speed = speed;
    }
}
