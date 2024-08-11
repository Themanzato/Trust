using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject FadeInicio;


    [SerializeField] private GameObject BotonPausa;
    [SerializeField] private GameObject MenuPausa;

    private bool pausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0;
        BotonPausa.SetActive(false);
        MenuPausa.SetActive(true);
    }

    public void Continuar()
    {
        Time.timeScale = 1;
        BotonPausa.SetActive(true);
        MenuPausa.SetActive(false);
    }
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
    }
}
