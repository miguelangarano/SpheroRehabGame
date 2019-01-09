using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Botones : MonoBehaviour {

    //nombre de escena que deseas cargar
    public string nextScene;
    public InputField input;

    void Start(){
        PlayerPrefs.SetString("Miguel", "");
    }

	public void Inicio()
    {
        Application.LoadLevel(nextScene);
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Estadisticas(){
        Application.LoadLevel("MenuNombreEstadistica");
    }

    public void Iniciar(){
        string name=input.text;
        if(name!="" && name!=null){
            PlayerPrefs.SetString(name, "");
            GameObject obj=GameObject.Find("PlayerData");
            Debug.Log(obj.GetComponent<PlayerData>().data);
            obj.GetComponent<PlayerData>().data=name;
            DontDestroyOnLoad(obj);
            Application.LoadLevel(nextScene);
        }
    }

    public void Regresar(){
        Application.LoadLevel("MenuInicio");
    }

    public void RegresarAnterior(){
        Debug.Log("Regr");
        Application.LoadLevel("MenuNombre");
    }

    public void VerEstadistica(){
        string name=input.text;
        if(name!="" && name!=null){
            PlayerPrefs.SetString(name, "");
            GameObject obj=GameObject.Find("PlayerData");
            Debug.Log(obj.GetComponent<PlayerData>().data);
            obj.GetComponent<PlayerData>().data=name;
            DontDestroyOnLoad(obj);
            Application.LoadLevel("EstadisticaScene");
        }
    }

   

    
}
