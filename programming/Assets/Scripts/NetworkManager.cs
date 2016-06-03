using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	// Update is called once per frame
	void Update () {

	}

	public override void OnJoinedLobby()
	{
		Debug.Log("In on joined lobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random Room!");
		PhotonNetwork.CreateRoom(null);
	}

	public override void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate("CartPlayer",new Vector3(0.48f,0,-9.49f), Quaternion.identity,0);
		Debug.Log("Connect to room");
	}

}
