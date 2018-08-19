using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

	public GameObject orb;


	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity=new Vector3(orb.GetComponent<MoveOrb>().orbVel,0,0);
	}
}
