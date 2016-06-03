using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickUp : MonoBehaviour {

	public static int counter = 0;


	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			counter++;
			Destroy(this.gameObject); // will eventually differentiate between type with tag and have adverse or positive effect accordingly
		}
		print ("number of   collected: " +counter);
		if (gameObject.name == "Banana 1(Clone)" || gameObject.name == "Watermelon 1(Clone)") {
			GameObject.Find("Game Manager").GetComponent<GameManager>().goodC += 1;
			GameObject.Find ("GoodText").GetComponent<Text> ().text = "Good items: " + GameObject.Find("Game Manager").GetComponent<GameManager>().goodC; 
		} else {
			GameObject.Find("Game Manager").GetComponent<GameManager>().badC += 1;
			GameObject.Find ("BadText").GetComponent<Text> ().text = "Bad items: " + GameObject.Find("Game Manager").GetComponent<GameManager>().badC;
		}
	}

}	