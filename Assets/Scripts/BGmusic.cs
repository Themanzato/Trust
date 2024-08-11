using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    public static BGmusic instance;

    public void Update()
    {

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Limbo" 
        || UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "EscenaInteractiva")

        {
            Destroy(gameObject);


        }

    }

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }   

    }
}