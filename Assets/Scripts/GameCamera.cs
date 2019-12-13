using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {



	private Vector3 cameraTarget;
	private Transform target;
	// Use this for initialization

	/// <summary>
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	/// </summary>
	void Start () {

		target = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		cameraTarget = new Vector3 (target.position.x, transform.position.y, target.position.z-8);
		transform.position = Vector3.Lerp (transform.position, cameraTarget, Time.deltaTime * 8);
		yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedH * Input.GetAxis ("Mouse Y");
		transform.eulerAngles = new Vector3(47.9f, yaw, 0.0f);
		
	}
}
