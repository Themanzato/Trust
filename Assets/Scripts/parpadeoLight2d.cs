using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parpadeoLight2d : MonoBehaviour
{


    private UnityEngine.Rendering.Universal.Light2D luz;
    private float intensidad;
    private bool aumentar = true;
    private void Awake()
    {
        luz = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    private void Update()
    {
        ParpadeoLuz();
        
    }
    
    void ParpadeoLuz()
    {
        if (aumentar)
        {
            intensidad += Time.deltaTime;
            if (intensidad >= 3f)
            {
                aumentar = false;
            }
        }
        else
        {
            intensidad -= Time.deltaTime;
            if (intensidad <= 0)
            {
                aumentar = true;
            }
        }
        luz.intensity = intensidad;
    }
   
}
