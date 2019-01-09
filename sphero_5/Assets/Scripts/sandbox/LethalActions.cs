using UnityEngine;
using System.Collections;

public class LethalActions : MonoBehaviour {

	public GameObject generalObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider){
		if(collider.gameObject.name == "Sphere"){
			//Debug.Log("lethal collided");
			generalObject.GetComponent<GeneralStats>().isDead=true;
		}
	}
}
