using UnityEngine;
using System.Collections;

public class AccessSphero : MonoBehaviour {

	public GameObject cam;
	public float pitch, roll;
	UpdateValues val;

	// Use this for initialization
	void Start () {
		val=cam.GetComponent<UpdateValues>();
	}
	
	// Update is called once per frame
	void Update () {

		pitch=val.pitch;
		roll=val.roll;

		Debug.Log("pitch: "+pitch);
		Debug.Log("roll: "+roll);

	}
}
