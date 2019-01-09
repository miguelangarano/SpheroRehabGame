using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour {

	GameObject prefab;
	GameObject cloned;
	double delay = 0.5;
	string[] obs=new string[9];

	// Use this for initialization
	void Start () {
		obs[0]="center";
		obs[1]="right";
		obs[2]="left";
		obs[3]="lethalcenter";
		obs[4]="lethalleft";
		obs[5]="lethalright";
		obs[6]="coincenter";
		obs[7]="coinleft";
		obs[8]="coinright";
		prefab=GameObject.Find("structure");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
		//Debug.Log("builder collided");
		float value=gameObject.transform.parent.gameObject.transform.position.z+10;
		cloned=(GameObject)Instantiate(prefab, new Vector3(0, 0, value), Quaternion.identity);
		//prefab.gameObject.transform.GetChild(0).gameObject.GetComponent<Builder>().prefab=GameObject.Find("structure");
		//Debug.Log(prefab.gameObject.name);
		selectObstacle();
		StartCoroutine(WaitAndDestroy());
	}
 
	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(0.3f);
		Destroy(gameObject.transform.parent.gameObject);
	}
	
	void selectObstacle(){
		int obstacle=Random.Range(0,9);
		GameObject obj = cloned.transform.Find(obs[obstacle]).gameObject;
		//Debug.Log(obj.gameObject.name+"   "+obstacle);

		if(obstacle==0 || obstacle==1 || obstacle==2){
			obj.GetComponent<MeshRenderer>().enabled=false;
		}else{
			obj.GetComponent<MeshRenderer>().enabled=true;
		}
		
		if(obstacle==6 || obstacle==7 || obstacle==8){
			obj.GetComponent<CapsuleCollider>().enabled=true;
		}else if(obstacle==0 || obstacle==1 || obstacle==2){
			obj.GetComponent<BoxCollider>().enabled=false;
		}else{
			obj.GetComponent<BoxCollider>().enabled=true;
		}
	}
}
