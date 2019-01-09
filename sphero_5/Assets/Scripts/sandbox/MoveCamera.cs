using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public GameObject player;
    private Vector3 _offset;

	// Use this for initialization
	void Start () {
		_offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + _offset;
	}
}
