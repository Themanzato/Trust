using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControladorBoton : MonoBehaviour
{
    public Image UIimagen;

    public void Start()
    {
        UIimagen = GameObject.Find("Derecha").GetComponent<Image>();
    }

    void Update()
    {
       
    }
}
