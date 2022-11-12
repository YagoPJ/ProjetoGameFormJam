using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Config")]
    public static int pontos = 0;
    public int life = 5;
    public float speed;
    public int bullets;
    public int maxBullets;
    [Header("Imports")]
    public GameObject bullet;
    public Text lifeTxt;
    public Text pontosTxt;
    public float yPos;
    public float xPos;
    public bool canReload = true;
    // Start is called before the first frame update
    void Start()
    {
        bullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTxt.text = life.ToString();
        pontosTxt.text = pontos.ToString();
        //movimento
        float y = Input.GetAxisRaw("Vertical");
        yPos += y * speed;
        yPos = Mathf.Clamp(yPos, -3.58f, 5.58f); // limitando o valor que a variavel pode ter
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

        float x = Input.GetAxisRaw("Horizontal");
        xPos += x * speed;
        xPos = Mathf.Clamp(xPos, -9.6f, 9.6f); // limitando o valor que a variavel pode ter
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        
        //atirar
        if (Input.GetKey(KeyCode.Space))
        {
            if (bullets > 0)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                bullets -= 1;
            }
        }

        //recarregar
        if(bullets < maxBullets && canReload == true)
        {
            canReload = false;
            StartCoroutine(Recarregar());
        }
    }

    IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(0.5f);
        bullets += 1;
        canReload = true;
    }
}
