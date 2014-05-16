using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {

	//public float distance = 5;
	//public float height = 10;

	private Vector3 cameraTarget;

	private Transform player;
	public Transform cameraTransform;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
//	void Update () {
//
//		cameraTarget = new Vector3(player.position.x, height, player.position.z);
//		transform.position = Vector3.Lerp(transform.position, cameraTarget, Time.deltaTime * 8);
//
//
//
//	}

	public Transform car;
	public float distance = 15f;
	public float height = 2.4f;
	public float rotationDamping = 3.0f;
	public float heightDamping = 2.0f;
	public float zoomRatio = 0.5f;
	public float defaultFOV = 60f;
	private Vector3 rotationVector;
	
	void LateUpdate () {
		
		float wantedAngle = rotationVector.y;
		float wantedHeight = car.position.y + height;
		float myAngle = transform.eulerAngles.y;
		float myHeight = transform.position.y;
		myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping*Time.deltaTime);
		myHeight = Mathf.Lerp(myHeight,wantedHeight, heightDamping*Time.deltaTime);
		Quaternion currentRotation = Quaternion.Euler(0,myAngle,0);
		transform.position = car.position;
		transform.position -= currentRotation*Vector3.forward*distance;
		Vector3 temp = transform.position;
		temp -= currentRotation*Vector3.forward*distance;
		temp.y = myHeight;
		transform.position = temp;
		transform.LookAt(car);
		
	}

	void Update(){
		ZoomScroll();
	}

	void ZoomScroll(){
		if(Input.GetAxis("Mouse Scroll")>0){
			height = height - 0.5f;
			distance = distance - 0.2f;
		}
		else if(Input.GetAxis("Mouse Scroll")<0){
			height = height + 0.5f;
			distance = distance + 0.2f;
		}

		if(height < 3.8f)
			height = 3.8f;
		if(height >12.38f)
			height = 12.38f;
		if(distance >4.6f)
			distance = 4.6f;
		if(distance < 1.8f)
			distance = 1.8f;

	}
}
