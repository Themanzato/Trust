using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionPersonaje : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;
    private GameManager2 gameManager;

    private void Start()
    {
        gameManager = GameManager2.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");
        index = 0;

        if (index > gameManager.personajes.Count - 1)
        {
            index = 0;
        }
        
        CambiarPantalla();
    }

    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = gameManager.personajes[index].imagen;
        nombre.text = gameManager.personajes[index].nombre;
    }

    public void SiguientePersonaje()
    {
        if (index == gameManager.personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        CambiarPantalla();
    }

    public void AnteriorPersonaje()
    {
        if (index == 0)
        {
            index = gameManager.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }

        CambiarPantalla();
    }
    
    public void IniciarJuego()
    {
        if (index == 0)
        {
            SceneManager.LoadScene("EscenaInteractiva");
        }
        else if (index == 1)
        {
            SceneManager.LoadScene("Limbo");
        }       
    }

    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
