using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {

	public static int counter = 0;

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			counter++;
			Destroy(this.gameObject); // will eventually differentiate between type with tag and have adverse or positive effect accordingly
		}
		print ("number of objects collected: " +counter); 
	}

}	