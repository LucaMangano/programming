using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public float prot;
	public float carbs;
	public float fat;
	public int count;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("ProtSlider").GetComponent<Slider> ().value = prot;
		GameObject.Find ("CarbsSlider").GetComponent<Slider> ().value = carbs;
		GameObject.Find ("FatSlider").GetComponent<Slider> ().value = fat;
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
