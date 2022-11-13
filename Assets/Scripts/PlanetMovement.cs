using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{

    Transform planet;
    Rigidbody rbPlanet;
    [SerializeField] Vector3 rotation;
    [SerializeField] Vector3 position;

    private void Start()
    {
        planet = GetComponent<Transform>();
        rbPlanet = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        planet.transform.Rotate(rotation * Time.deltaTime);
        rbPlanet.velocity = new Vector3(50, 0, 0);
    }
}
