using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dragDrop : MonoBehaviour {

	public GameObject gameControl;

	private bool dragging = false;
	private float distance;
	GameObject drag;
	float shelf0x;
	float shelf1x;
	float shelf2x;
	float shelf3x;
	float shelf4x;
	float shelf5x;
	float shelf0y;
	float shelf1y;
	float shelf2y;
	float shelf3y;
	float shelf4y;
	float shelf5y;

	public float carb;
	public float fat;
	public float prot;

	private int count;

	void Start(){
		GameObject.Find ("Errors").GetComponent<Text> ().text = "Select "+ (5 - gameControl.GetComponent<GameControl> ().count) +" more object(s)";
	}

	void OnMouseDown()
	{
		if (gameObject.name.Contains("drag")) {
			Destroy (gameObject);
			gameControl.GetComponent<GameControl> ().count -= 1;
			gameControl.GetComponent<GameControl> ().RemoveCarb (carb);
			gameControl.GetComponent<GameControl> ().RemoveFat (fat);
			gameControl.GetComponent<GameControl> ().RemoveProt (prot);
			GameObject.Find ("Errors").GetComponent<Text> ().text = "Select "+ (5 - gameControl.GetComponent<GameControl> ().count) +" more object(s)";
		} else {
			if (gameControl.GetComponent<GameControl>().count < 5) {
				distance = Vector3.Distance (transform.position, Camera.main.transform.position);
				dragging = true;
				drag = Instantiate (gameObject);
				drag.name = "drag"+gameObject.name;
			} else {
				GameObject.Find ("Errors").GetComponent<Text> ().text = "Too many objects,\ndelete some";
			}
		}
	}

	void OnMouseUp()
	{
		if (gameControl.GetComponent<GameControl> ().count < 5) {
			dragging = false;
			drag.transform.position = new Vector3 (drag.transform.position.x, drag.transform.position.y, 553);
			if (drag.transform.position.x < 0) {
				gameControl.GetComponent<GameControl> ().AddToCarb (carb);
				gameControl.GetComponent<GameControl> ().AddToFat (fat);
				gameControl.GetComponent<GameControl> ().AddToProt (prot);
				gameControl.GetComponent<GameControl> ().count += 1;
				GameObject.Find ("Errors").GetComponent<Text> ().text = "Select "+ (5 - gameControl.GetComponent<GameControl> ().count) +" more object(s)";
			}
		}
		
	}

	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(554.0f);
			drag.transform.position = rayPoint;
		}
	}
}
