using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Estadistica : MonoBehaviour {

	public Text texto;

	// Use this for initialization
	void Start () {
		Debug.Log("Alog");
		string name=GameObject.Find("PlayerData").GetComponent<PlayerData>().data;
		string data=PlayerPrefs.GetString(name);
		Debug.Log("Prueba: "+name+"   "+data);
		if(data!="" && data!=null){
			texto.text=data;
		}else{
			texto.text="No hay datos del jugador.";
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Salir(){
		Application.LoadLevel("MenuNombreEstadistica");
	}
}
