using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicaIntro : MonoBehaviour
{
    public bool esPrimeraVez = true;

    private const string PrimeraVezKey = "EsPrimeraVez";

    void Awake()
    {
        if (PlayerPrefs.HasKey(PrimeraVezKey))
        {
            esPrimeraVez = PlayerPrefs.GetInt(PrimeraVezKey) == 1;
        }
        else
        {
            PlayerPrefs.SetInt(PrimeraVezKey, 1);
            PlayerPrefs.Save();
        }

        if (!esPrimeraVez)
        {
            SceneManager.LoadScene("MenuPrincipal");
        }
    }

    void Start()
    {
        if (esPrimeraVez)
        {
           
            esPrimeraVez = false;
            PlayerPrefs.SetInt(PrimeraVezKey, 0);
            PlayerPrefs.Save();
        }
    }
}
