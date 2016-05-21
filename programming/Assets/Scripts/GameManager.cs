using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	private Maze mazeInstance;

	public int rows;
	private int offset;
	private bool even;
	private int count;

	private void Start () {
		count = 1;
		offset = 0;
		rows = 3;
	}

	private void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (count % 2 == 0) {
				even = true;
			} else {
				even = false;
			}
			print (even);
			BeginGame ();
			offset += 2;
			count += 1;
		} else if (Input.GetKeyDown (KeyCode.P)) {
			ClearPassages ();
		}
	}

	private void BeginGame () {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		mazeInstance.name = even.ToString()+"_"+count;
		mazeInstance.transform.position = new Vector3 (mazeInstance.transform.position.x + offset, mazeInstance.transform.position.y, mazeInstance.transform.position.z);
		StartCoroutine(mazeInstance.Generate(even));
	}

	private void RestartGame () {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}

	private void ClearPassages(){
		for (int i = 1; i < count; i++) {
			string name;
			if (i % 2 == 0) {
				Destroy(GameObject.Find ("True_" + i).gameObject.transform.Find("Maze Cell 0, 19").gameObject.transform.Find ("Maze Wall(Clone)_West").gameObject);
				Destroy(GameObject.Find ("True_" + i).gameObject.transform.Find("Maze Cell 1, 0").gameObject.transform.Find ("Maze Wall(Clone)_East").gameObject);
				for (int k = 0; k < 2; k++) {
					for (int j = 0; j < 20; j++) {
						if (k == 0) {
							if(GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_East") != null){
								Destroy (GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_East").gameObject);
							}
						} else {
							if (GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_West") != null) {
								Destroy (GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_West").gameObject);
							}
						}

						if (j != 0 && j != 19) {
							if(GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South") != null){
								Destroy (GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South").gameObject);
							}
							if(GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North") != null){
								Destroy (GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North").gameObject);
							}
						}
					}
				}
			} else {
				Destroy(GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell 1, 19").gameObject.transform.Find ("Maze Wall(Clone)_East").gameObject);
				Destroy(GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell 0, 0").gameObject.transform.Find ("Maze Wall(Clone)_West").gameObject);
				for (int k = 0; k < 2; k++) {
					for (int j = 0; j < 20; j++) {
						if (k == 0) {
							if(GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_East") != null){
								Destroy (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_East").gameObject);
							}
						} else {
							if (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_West") != null) {
								Destroy (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_West").gameObject);
							}
						}

						if (j != 0 && j != 19) {
							if (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South") != null) {
								Destroy (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South").gameObject);
							}
							if (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North") != null) {
								Destroy (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North").gameObject);
							}
						} else if (j == 0) {
							if (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North") != null) {
								Destroy (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North").gameObject);
							}
						} else if (j == 19) {
							if (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South") != null) {
								Destroy (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South").gameObject);
							}
						}
					}
				}
			}




		}
			
	}
}