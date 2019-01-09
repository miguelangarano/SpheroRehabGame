using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneralStats : MonoBehaviour {

	public int coins=0;
	public bool isDead=false;
	public float sphereSpeed=10;
	public int level=1;
	public Text texto;
	public Text cointext;

	// Use this for initialization
	void Start () {
		cointext.text="Monedas: "+coins;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Coins: "+coins+" Level: "+level+" Speed: "+sphereSpeed);
		cointext.text="Monedas: "+coins;
		if(coins==5*level){
			level++;
			sphereSpeed=sphereSpeed+5;
			texto.text="Nivel "+level;
			StartCoroutine(CleanText());
		}

		if(isDead){
			texto.text="¡Felicidades!. \n Has llegado al nivel "+level+".\n Vuelve a intentarlo.";
			StartCoroutine(RestartLevel());
		}
	}

	void SavePlayerData(){
		string name=GameObject.Find("PlayerData").GetComponent<PlayerData>().data;
		string playdata=PlayerPrefs.GetString(name);
		Debug.Log(playdata+"   "+name);
		PlayerPrefs.SetString(name, playdata+",{level: "+level+", time: "+Time.timeSinceLevelLoad+"}");
	}

	IEnumerator RestartLevel(){
		yield return new WaitForSeconds(1f);
		texto.text="";
		SavePlayerData();
		Application.LoadLevel("SensorCustom");
	}

	IEnumerator CleanText(){
		yield return new WaitForSeconds(0.5f);
		texto.text="";
	}

	void Salir(){
		Application.LoadLevel("MenuInicio");
    }

    void Reiniciar(){
        Application.LoadLevel("SensorCustom");
    }
}
