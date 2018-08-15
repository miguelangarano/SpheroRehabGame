using UnityEngine;
using System.Collections;

public class MoveOrb : MonoBehaviour {

	public KeyCode moveL;
	public KeyCode moveR;
	public float horizontalVel=0;
	public int laneNum=2;
	public GameObject cam;
	UpdateValues val;
	public float pitch, roll;

	// Use this for initialization
	void Start () {
		val=cam.GetComponent<UpdateValues>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity=new Vector3(4,0,horizontalVel);

		pitch=val.pitch;
		roll=val.roll;

		/*if(Input.GetKeyDown(moveL)){
			horizontalVel=2;
			StartCoroutine(stopSlide());
			laneNum+=1;
		}
		if(Input.GetKeyDown(moveR)){
			horizontalVel=-2;
			StartCoroutine(stopSlide());
			laneNum-=1;
		}*/


		if(pitch>20){
			horizontalVel=2;
			StartCoroutine(stopSlide());
			laneNum+=1;
			pitch=0;
		}
		if(pitch<-20){
			horizontalVel=-2;
			StartCoroutine(stopSlide());
			laneNum-=1;
			pitch=0;
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag=="lethal"){
			Destroy(gameObject);
		}
	}


	IEnumerator stopSlide(){
		yield return new WaitForSeconds(.5f);
		horizontalVel=0;
	}
}
