using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour
{
    float degree;
    float velocity = 0.5f;

    void Start()
    {
        degree = 0;
    }

    void Update()
    {
        degree += Time.deltaTime * velocity;
        if (degree >= 360)
            degree = 0;

        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }
}