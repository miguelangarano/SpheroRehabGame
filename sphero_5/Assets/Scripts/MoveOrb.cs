using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveOrb : MonoBehaviour {

    public static int indice =0;
	public KeyCode moveL;
	public KeyCode moveR;
	public float horizontalVel=0, verticalVel=0;
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
	public Rigidbody obj;

	// Use this for initialization
	void Start () {
		val=cam.GetComponent<UpdateValues>();
		obj=GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Rigidbody>().velocity=new Vector3(orbVel,0,horizontalVel);

		if(obj.position.z>0.6f){
			obj.transform.position=new Vector3(obj.position.x, obj.position.y, 0.6f);
		}else if(obj.position.z<-2.2f){
			obj.transform.position=new Vector3(obj.position.x, obj.position.y, -2.2f);
		}

		if(obj.position.y<=-1){
			obj.useGravity=false;
		}

		obj.velocity=new Vector3(orbVel,verticalVel,horizontalVel);

		pitch=val.pitch;
		roll=val.roll;

		if(Input.GetKeyDown(moveL)){
			horizontalVel=2+horizontalVel;
		}

		if(Input.GetKeyDown(moveR)){
			horizontalVel=-2+horizontalVel;
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			obj.AddForce(new Vector3(0, 300, 0), ForceMode.Impulse);
			obj.useGravity=true;
		}

		if(roll>20){
			horizontalVel=2;
		}
		if(roll<-20){
			horizontalVel=2;
		}
		if(roll>-10 && roll<10){
			horizontalVel=0;
		}

		if(pitch<-20){
			obj.AddForce(new Vector3(0, 300, 0), ForceMode.Impulse);
			obj.useGravity=true;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "lethal") {
			audioLose.Play();
			Destroy (gameObject);
			PlayerPrefs.SetInt("monedas",coins);
			Restart();
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "moveEvent") {
			collided=true;

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
		}
	}


	IEnumerator stopSlide(){
		yield return new WaitForSeconds(.5f);
		horizontalVel=0;
	}

	IEnumerator move(GameObject other){
		yield return new WaitForSeconds (1f);
		Destroy (other);
		distanceValue=distanceValue+2;
		GameObject other1=(GameObject)Instantiate(myPrefab);
        if(indice!=7)
        {
            indice++;
        }
        else
        {
            indice = 0;
        }
		other1.transform.position=new Vector3(distanceValue,0f,0f);
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
			initialize = init[num1];
			interiorize = interior[num2];
			if(num1!=2){
				GameObject side=	other.transform.GetChild (init [num1]).GetChild (interior [num2]).gameObject;
				side.GetComponent<Collider> ().enabled = true;
				side.GetComponent<MeshRenderer> ().enabled = true;
			}
			
		} else {
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
			initialize = init[num1];
			interiorize = interior[num2];
			if(num1!=2){
				GameObject side=	other.transform.GetChild (init [num1]).GetChild (interior [num2]).gameObject;
				side.GetComponent<Collider> ().enabled = true;
				side.GetComponent<MeshRenderer> ().enabled = true;
			}
			
		}
	}

	public void Restart(){
		Application.LoadLevel("SensorCustom");
	}

	public void Salir(){
		Application.LoadLevel("MenuInicio");
	}

}
