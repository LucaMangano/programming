using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Photon;

public class CartController : Photon.MonoBehaviour
{
	public AnimationCurve RotationSpeedCurve;
	public Rigidbody RigidB;

	[SerializeField]
	private float _movementSpeed = 0.0f;

	public float MaxSpeed = 5.0f;
	public float MaxAcceleration = 2.0f;

	private float _deceleration = 3.1f;

	public float RotationSpeed = 20.0f;

	public float carbs;
	public float prot;
	public float fat;

	public Camera CartCamera;

	// SYNCHRONIZATION
	private float lastSynchronizationTime = 0f;
	private float synchDelay = 0f;
	private float synchTime = 0f;
	private Vector3 synchPosition;
	private Vector3 synchVelocity;
	private Vector3 synchStartPosition = Vector3.zero;
	private Vector3 synchEndPosition = Vector3.zero;

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		/*if(stream.isWriting)
		{
			stream.SendNext(RigidB.position);
			stream.SendNext(RigidB.velocity);
		} 
		else
		{
			synchPosition = (Vector3)stream.ReceiveNext();
			synchVelocity = (Vector3)stream.ReceiveNext();

			synchTime = 0f;
			synchDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;

			synchEndPosition = synchPosition + synchVelocity * synchDelay;
			synchStartPosition = RigidB.position;
		}

		if (stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(RigidB.velocity);
		} else 
		{
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();
			RigidB.velocity = (Vector3)stream.ReceiveNext();
		}*/

	}


	void Update()
	{
		PhotonView pv = PhotonView.Get(this);

		if(pv.isMine){
			InputMovement();
			CartCamera.enabled = true;
		}
	}

	void Start(){
		PhotonView pv = PhotonView.Get(this);
		if (pv.isMine){
			CartCamera.gameObject.SetActive(true);			
		}
	}
	void InputMovement(){
		//var pos = transform.localPosition;
		//pos.y = 0.58f;
		//transform.localPosition = pos;
		transform.localRotation = Quaternion.Euler(0.0f, transform.localRotation.eulerAngles.y, 0.0f);

		_movementSpeed *= 1.0f - ((Time.deltaTime * 0.7f) * RotationSpeedCurve.Evaluate(Mathf.Abs(_movementSpeed) / MaxSpeed));

		_movementSpeed += MaxAcceleration * (Input.GetAxis("Acceleration") - Input.GetAxis("Deceleration") + Input.GetAxis("Vertical")) * Time.deltaTime;
		_movementSpeed = Mathf.Clamp(_movementSpeed, -MaxSpeed / 2.0f, MaxSpeed);

		transform.Rotate(Vector3.down, -Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime * RotationSpeedCurve.Evaluate(Mathf.Abs(_movementSpeed) / MaxSpeed));

		RigidB.velocity = transform.localRotation * Vector3.forward * _movementSpeed;
		RigidB.angularVelocity = Vector3.zero;
	}

}
