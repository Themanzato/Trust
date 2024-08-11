using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personajes")]

public class Personajes : ScriptableObject
{
    public GameObject personajeJugabe;
    public Sprite imagen;
    public string nombre; 
}
