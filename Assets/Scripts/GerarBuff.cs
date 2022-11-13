using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarBuff : MonoBehaviour
{
    public GameObject[] listaBuffs;
    //public Inimigos inimigo;
    public bool criar = true;
    public float timeCreate;

    [SerializeField]
    PlayerController pC;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject inimigosLista = listaInimigo[Random.Range(0, listaInimigo.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        if(criar == true && pC.canMove == true)
        {
            criar = false;
            StartCoroutine(criarInimigo());
        }
    }

    IEnumerator criarInimigo()
    {
        GameObject buffsLista = listaBuffs[Random.Range(0, listaBuffs.Length - 1)];
        yield return new WaitForSeconds(timeCreate);
        criar = true;
        float y = Random.Range(-4.78f, 4.78f);
        float speed = Random.Range(0.01f, 0.05f);
        Buffs buff = Instantiate(buffsLista, transform.position + new Vector3(0, y, 0), transform.rotation = Quaternion.Euler(180, 90, -90)).GetComponent<Buffs>();
        buff.speed = speed;
    }
}
