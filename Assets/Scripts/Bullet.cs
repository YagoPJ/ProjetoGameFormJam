using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TimeDestroy());
        transform.position += new Vector3(2f, 0, 0);
        transform.rotation = Quaternion.Euler(0, 180, -90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.25f, 0, 0);
        if(transform.position.x > 13.26f)
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
