using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shelfSize : MonoBehaviour {

	public void changeShelfWidth(){
		float value = GameObject.Find ("SliderWidth").GetComponent<Slider>().value;
		for (int i = 0; i < 6; i++) {
			GameObject obj = GameObject.Find ("shelf" + i);
			obj.transform.localScale = new Vector3(value, obj.transform.localScale.y, obj.transform.localScale.z);
		}
		GameObject temp = GameObject.Find ("shelf0");
		for (int i = 0; i < 5; i++) {
			GameObject obj1 = GameObject.Find("sideLeft"+i);
			GameObject obj2 = GameObject.Find("sideRight"+i);
			obj1.transform.position = new Vector3 (temp.transform.position.x - temp.GetComponent<Renderer> ().bounds.size.x / 2, obj1.transform.position.y, obj1.transform.position.z);
			obj2.transform.position = new Vector3 (temp.transform.position.x + temp.GetComponent<Renderer> ().bounds.size.x / 2, obj2.transform.position.y, obj2.transform.position.z);
		}
		for (int i = 1; i <= 4; i++) {
			GameObject foot = GameObject.Find ("foot" + i);
			if (i == 1 || i == 3) {
				foot.transform.position = new Vector3 (temp.transform.position.x - temp.GetComponent<Renderer> ().bounds.size.x / 2 + 20, foot.transform.position.y, foot.transform.position.z);
			} else {
				foot.transform.position = new Vector3 (temp.transform.position.x + temp.GetComponent<Renderer> ().bounds.size.x / 2 - 20, foot.transform.position.y, foot.transform.position.z);

			}
		}
	}

	public void changeShelfHieght(){
		float value = GameObject.Find ("SliderHeight").GetComponent<Slider>().value;
		for (int i = 0; i < 6; i++) {
			GameObject obj = GameObject.Find ("shelf" + i);
			obj.GetComponent<Renderer> ().enabled = false;
		}
		for (int i = 0; i < 6; i++) {
			if (i <= value) {
				GameObject obj = GameObject.Find ("shelf" + i);
				obj.GetComponent<Renderer> ().enabled = true;
			}
		}

		for (int i = 0; i < 5; i++){
			if(i < value){
				GameObject obj1 = GameObject.Find("sideLeft"+i);
				obj1.GetComponent<Renderer> ().enabled = true;
				GameObject obj2 = GameObject.Find("sideRight"+i);
				obj2.GetComponent<Renderer> ().enabled = true;
			} else {
				GameObject obj3 = GameObject.Find("sideLeft"+i);
				obj3.GetComponent<Renderer> ().enabled = false;
				GameObject obj4 = GameObject.Find("sideRight"+i);
				obj4.GetComponent<Renderer> ().enabled = false;
			}
		}
			
	}
}
