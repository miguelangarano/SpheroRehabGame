using UnityEngine;
using System.Collections;

public class Botones : MonoBehaviour {

    //nombre de escena que deseas cargar
    public string nextScene;

	public void Inicio()
    {
        Application.LoadLevel(nextScene);
    }

    public void Salir()
    {
        Application.Quit();
    }

   

    
}
