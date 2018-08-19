using UnityEngine;
using System.Collections;

public class MoveCoins : MonoBehaviour {



	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().angularVelocity=new Vector3(0,2,0);
	}
	
}
