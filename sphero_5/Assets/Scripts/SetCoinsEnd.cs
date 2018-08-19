using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetCoinsEnd : MonoBehaviour {
	
	public Text ptj;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		ptj.text = "" + PlayerPrefs.GetInt ("monedas");
		audio.Play ();
	}

	public void Restart(){
		Application.LoadLevel("SensorCustom");
	}
	
	public void Salir(){
		Application.Quit();
	}
}
