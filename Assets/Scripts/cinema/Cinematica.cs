using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public GameObject canvas;
    public GameObject dialogBoxText;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;

        /*if (elapsedTime >= 22f)
        {
            canvas.SetActive(true);
            dialogBoxText.SetActive(true);
        }


*/
        if (elapsedTime >= 10.35f)
        {
            CinemachineMovimientoCamara.Instance.MoverCamara(1, 1, 0.5f);

            //detener movimiento de la camara
            if (elapsedTime >= 11.5f)
            {
                CinemachineMovimientoCamara.Instance.MoverCamara(0, 0, 0.1f);
            }
        }

        if (elapsedTime >= 37f)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }


    }
}
