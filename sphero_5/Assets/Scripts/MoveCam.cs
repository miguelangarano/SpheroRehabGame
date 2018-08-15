using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity=new Vector3(4,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
