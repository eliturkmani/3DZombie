using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour {
	//system
	private Quaternion targetRotation;

	//references the animator
	Animator myAnim;

	//componenets
	private CharacterController controller;

	// to change mouse position from screen space to world space position
	private Camera cam;

	public float rotationSpeed = 360;
	public float walkSpeed = 5;
	public float runSpeed = 8;


	// Use this for initialization
	void Start () {
		myAnim = GetComponent <Animator> ();
		controller = GetComponent <CharacterController> ();
		cam = Camera.main;
		
	}
	
	// Update is called once per frame , 
	void Update () {

		ControlMouse ();
		
	}
	void FixedUpdate(){
			// get all Axis that are defines diffrent key  edit > projsetting > input incldues the axis
			// get axis retuirn a value between -1 to 1 a = (-1,0) d= (0,1), 0 no key is pressed > 0 d is pressed < 0 a is pressed
			//float move = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis ("Vertical");
		float moveH = Input.GetAxis ("Horizontal");


			// take the absolut value of move since we dont care which direction player is moving to transition into a running state in animator
			//send the value to myAnime
		myAnim.SetFloat ("speedH" , Mathf.Abs(moveH));
		myAnim.SetFloat ("speedV" , Mathf.Abs(moveV));

		
	}
	void ControlMouse(){
		
		// get mouse position
		Vector3 mousePos = Input.mousePosition;
		mousePos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
		targetRotation = Quaternion.LookRotation (mousePos - new Vector3 (transform.position.x ,0,transform.position.z));
		//look at mouse postion
		transform.eulerAngles = Vector3.up * 
			Mathf.MoveTowardsAngle (transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0,Input.GetAxisRaw ("Vertical"));

		Vector3 motion = input;
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1)?0.7f:1 ; 
		motion *= (Input.GetButton ("Run"))?runSpeed:walkSpeed;
		motion += Vector3.up * -8;
		controller.Move (motion * Time.deltaTime);

		//myRB.velocity = new Vector3 (0, myRB.velocity.y, move * runSpeed);
	}


		

}
