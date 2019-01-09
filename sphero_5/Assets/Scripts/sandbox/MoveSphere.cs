using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour {

    public GameObject generalObject;
    float speed;
    bool isGrounded=true;

	// Use this for initialization
	void Start () {
	
	}

    void Update(){
        speed=generalObject.GetComponent<GeneralStats>().sphereSpeed;
    }

	void FixedUpdate ()
    {
        if(gameObject.transform.position.y<0.76){
            isGrounded=true;
        }else{
            isGrounded=false;
        }
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = 10;
        Vector3 movement = new Vector3 (moveHorizontal, 0, 1);
        //moveVertical=0;
        gameObject.GetComponent<Rigidbody>().AddForce (movement * speed);
        if (Input.GetKeyDown (KeyCode.Space) && isGrounded){
            //gameObject.GetComponent<Rigidbody>().AddForce (0, 477, 0);
        //    moveVertical=30;
        //    Debug.Log("jump");
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(moveHorizontal, moveVertical, 1) , ForceMode.Impulse);
            isGrounded=false;
        }

        if(gameObject.transform.position.y<=0.6f){
            generalObject.GetComponent<GeneralStats>().isDead=true;
        }
    }
}
