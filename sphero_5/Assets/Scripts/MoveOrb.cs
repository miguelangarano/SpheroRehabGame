using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveOrb : MonoBehaviour {

	public KeyCode moveL;
	public KeyCode moveR;
	public float horizontalVel=0;
	public int laneNum=2;
	public GameObject cam;
	UpdateValues val;
	public float pitch, roll;
	public string moveEvent="";
	public float distanceValue=18;
	bool leftReached=false, rightReached=false;
	public bool calculateTokens=false;
	public int coins=0;
	int initialize=-1, interiorize=-1;
	public AudioSource audioLose, audioCoin;
	public Text ptj;
	public float orbVel=2f;
	bool collided=false;
	public GameObject myPrefab;
	public float horizontalmulti=0f;

	// Use this for initialization
	void Start () {
		val=cam.GetComponent<UpdateValues>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity=new Vector3(orbVel,0,horizontalVel);



		pitch=val.pitch;
		roll=val.roll;

		if(Input.GetKeyDown(moveL) && leftReached==false){
			horizontalVel=2+horizontalmulti;
			StartCoroutine(stopSlide());
			laneNum+=1;
		}

		if(Input.GetKeyDown(moveR) && rightReached==false){
			horizontalVel=-2-horizontalmulti;
			StartCoroutine(stopSlide());
			laneNum-=1;
		}


		if(pitch>20){
			horizontalVel=2+horizontalmulti;
			StartCoroutine(stopSlide());
			laneNum+=1;
			pitch=0;
		}
		if(pitch<-20){
			horizontalVel=-2-horizontalmulti;
			StartCoroutine(stopSlide());
			laneNum-=1;
			pitch=0;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "lethal") {
			audioLose.Play();
			Destroy (gameObject);
			PlayerPrefs.SetInt("monedas",coins);
			Terminar();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "moveEvent") {
			collided=true;
			//distanceValue=distanceValue+2;
			//other.gameObject.transform.parent.transform.position=new Vector3(distanceValue,0f,0f);

			//GameObject other1=other.gameObject.transform.parent.transform.parent.gameObject;

			StartCoroutine (move (other.gameObject.transform.parent.transform.parent.gameObject));
		} else if (other.gameObject.tag == "collis") {
			if (other.gameObject.name == "Right") {
				rightReached = true;
			} else if (other.gameObject.name == "Center") {
				rightReached = false;
				leftReached = false;
			} else if (other.gameObject.name == "Left") {
				leftReached = true;
			}
		} else if (other.gameObject.tag == "coins") {
			coins++;
			audioCoin.Play();
			ptj.text="Monedas: "+coins;
			Destroy (other.gameObject);
			//Debug.Log(coins);
		}
	}


	IEnumerator stopSlide(){
		yield return new WaitForSeconds(.5f);
		horizontalVel=0;
	}

	IEnumerator move(GameObject other){
		yield return new WaitForSeconds (1f);
		//distanceValue=distanceValue+2;
		//other.transform.position=new Vector3(distanceValue,0f,0f);
		//Debug.Log(other.name);
		//GenerateTokens(other);
		Destroy (other);
		distanceValue=distanceValue+2;
		GameObject other1=(GameObject)Instantiate(myPrefab);
		other1.transform.position=new Vector3(distanceValue,0f,0f);
		Debug.Log(other1.name);
		GenerateTokens(other1);
	}

	void GenerateTokens(GameObject other){
		if (initialize == -1) {
			int[] init = new int[3];
			init [0] = 0;
			init [1] = 1;
			init[2]=-1;
			int[] interior = new int[3];
			interior [0] = 0;
			interior [1] = 1;
			interior [2] = 2;
			int num1 = Random.Range (0, 3);
			int num2 = Random.Range (0, 3);
			//Debug.Log("num1: "+num1+" num2: "+num2);
			initialize = init[num1];
			interiorize = interior[num2];
			if(num1!=2){
				//GameObject group = other.transform.GetChild (init [num1]).gameObject;
				Debug.Log("Linea 129");
				Debug.Log("Line: 129: init: "+init [num1]+" interior: "+interior [num2]+" ChildCount: "+other.transform.GetChild (init [num1]).childCount);
				Debug.Log("Line: 129: "+other.transform.GetChild (init [num1]).GetChild (interior [num2]).gameObject.name);
				Debug.Log("----------------------");
				GameObject side=	other.transform.GetChild (init [num1]).GetChild (interior [num2]).gameObject;
				
				side.GetComponent<Collider> ().enabled = true;
				side.GetComponent<MeshRenderer> ().enabled = true;
			}
			
		} else {
			//GameObject group = other.transform.GetChild (initialize).gameObject;
			//GameObject side=	other.transform.GetChild (initialize).GetChild (interiorize).gameObject;
			//Debug.Log("Line 139: "+other.transform.GetChild (initialize).GetChild (interiorize).gameObject.name);
			//Debug.Log("Line 139: init: "+initialize+" interior: "+interiorize);
			//side.GetComponent<Collider> ().enabled = false;
			//side.GetComponent<MeshRenderer> ().enabled = false;
			
			int[] init = new int[3];
			init [0] = 0;
			init [1] = 1;
			init[2]=-1;
			int[] interior = new int[3];
			interior [0] = 0;
			interior [1] = 1;
			interior [2] = 2;
			int num1 = Random.Range (0, 3);
			int num2 = Random.Range (0, 3);
			//Debug.Log("num1: "+num1+" num2: "+num2);
			initialize = init[num1];
			interiorize = interior[num2];
			if(num1!=2){
				//group = other.transform.GetChild (init [num1]).gameObject;
				//side = group.transform.GetChild (interior [num2]).gameObject;
				Debug.Log("Linea 159");
				Debug.Log("Line 159: init: "+init [num1]+" interior: "+interior [num2]+" ChildCount: "+other.transform.GetChild (init [num1]).childCount);
				Debug.Log("Line 159: "+other.transform.GetChild (init [num1]).GetChild (interior [num2]).gameObject.name);
				Debug.Log("----------------------");
				GameObject side=	other.transform.GetChild (init [num1]).GetChild (interior [num2]).gameObject;
				
				side.GetComponent<Collider> ().enabled = true;
				side.GetComponent<MeshRenderer> ().enabled = true;
			}
			
		}
	}

	public void Restart(){
		Application.LoadLevel("SensorCustom");
	}

	public void Terminar(){
		Application.LoadLevel("EndGame");
	}

}
