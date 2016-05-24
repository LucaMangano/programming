using UnityEngine;
using System.Collections;

public class statsChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void SetProt(){
		GameObject obj = GameObject.Find ("ProtFill");
		obj.transform.position = new Vector3 (150, obj.transform.position.y, obj.transform.position.z);
	}
}
