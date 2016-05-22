using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public float prot;
	public float carbs;
	public float fat;
	public int count;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadExplorer(){
		DontDestroyOnLoad (gameObject);
		Application.LoadLevel ("Scene");
	}

	public void AddToProt(float value){
		prot += value;
	}

	public void AddToCarb(float value){
		carbs += value;
	}

	public void AddToFat(float value){
		fat += value;
	}


}
