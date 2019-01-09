using UnityEngine;
using System.Collections;

public class CoinActions : MonoBehaviour {

	public GameObject generalObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "Sphere"){
			//Debug.Log("coin collided");
			generalObject.GetComponent<GeneralStats>().coins++;
			gameObject.GetComponent<MeshRenderer>().enabled=false;
		}
	}
}
