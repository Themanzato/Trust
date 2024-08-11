using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{

[SerializeField] private GameObject fondo;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fondo.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);

        }
    }

    
}
