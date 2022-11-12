using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSkyBox : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 5f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
    }
}
