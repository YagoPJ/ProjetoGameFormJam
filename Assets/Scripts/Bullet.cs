using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TimeDestroy());
        transform.position += new Vector3(1.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f, 0, 0);
        if(transform.position.x > 11.2f)
        {
            Destroy(gameObject);
        }
    }

    /*IEnumerator TimeDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    */
}
