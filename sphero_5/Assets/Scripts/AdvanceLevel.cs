using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdvanceLevel : MonoBehaviour {

	public GameObject orb;
	int coinsold=0, coinsnew=0;
	MoveOrb moveOrb;
	public Text levelText;
	int level=2;

	void Start(){
		moveOrb = orb.GetComponent<MoveOrb> ();
		levelText.GetComponent<Text> ().enabled = true;
		StartCoroutine(showLevel());
	}

	// Update is called once per frame
	void Update () {
		coinsnew=moveOrb.coins;
		if (coinsnew - coinsold == 5) {
			moveOrb.orbVel=moveOrb.orbVel+0.5f;
			level++;
			levelText.GetComponent<Text> ().enabled = true;
			StartCoroutine(showLevel());
			coinsold=coinsnew;
			moveOrb.horizontalmulti=moveOrb.horizontalmulti+0.1f;
		}
	}

	IEnumerator showLevel(){
		yield return new WaitForSeconds(.5f);
		levelText.text="NIVEL "+level;
		levelText.GetComponent<Text> ().enabled = false;
	}
}
