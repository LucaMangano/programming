using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	private Maze mazeInstance;

	//private GameObject player;
	public GameObject good1;
	public GameObject bad1;
	public GameObject good2;
	public GameObject bad2;
	public GameObject good3;
	public GameObject bad3;

	public int goodC;
	public int badC;

	public int rows;
	private int offset;
	private bool even;
	private int count;

	private void Start () {
		goodC = 0;
		badC = 0;
		count = 1;
		offset = 0;
		rows = 3;
		try{
			GameControl contr = GameObject.Find ("GameController1").GetComponent<GameControl>();
			CartController cc = GameObject.Find ("Player").GetComponent<CartController> ();
			cc.carbs = contr.carbs;
			cc.fat = contr.fat;
			cc.prot = contr.prot;
			Destroy(contr);
		} catch {
		}

		BeginGame ();
		even = true;
		offset += 2;
		count += 1;
		BeginGame ();
		even = false;
		offset += 2;
		count += 1;
		BeginGame ();
		even = true;
		offset += 2;
		count += 1;

	}

	private void Update () {
		/*if (Input.GetKeyDown (KeyCode.Return)) {
			if (count % 2 == 0) {
				even = true;
			} else {
				even = false;
			}
			print (even);
			BeginGame ();
			offset += 2;
			count += 1;
		} else 
		if (Input.GetKeyDown (KeyCode.P)) {
			ClearPassages ();
		}*/
		if(GameObject.FindGameObjectWithTag("Player").transform.position.x >= 5.3f) {
		//if (GameObject.Find ("Player").transform.position.x >= 5.3f) {
			Application.LoadLevel ("Finish");
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

	public void ClearPassages(){
		Destroy (GameObject.Find ("Button"));
		for (int i = 1; i < count; i++) {
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
								GameObject obj = GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South").gameObject;
								GameObject toInstantiate;
								int rand = Random.Range (1, 4);
								if (rand == 1) {
									toInstantiate = bad1;
								} else if (rand == 2) {
									toInstantiate = bad2;
								} else if (rand == 3) {
									toInstantiate = bad3;
								} else {
									toInstantiate = bad3;
								}
								GameObject instance = Instantiate (toInstantiate);
								instance.transform.position = obj.transform.position;
								Destroy (obj);
							}
							if(GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North") != null){
								GameObject obj = GameObject.Find ("True_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North").gameObject;
								GameObject toInstantiate;
								int rand = Random.Range (1, 4);
								if (rand == 1) {
									toInstantiate = good1;
								} else if (rand == 2) {
									toInstantiate = good2;
								} else if (rand == 3) {
									toInstantiate = good3;
								} else {
									toInstantiate = good3;
								}
								GameObject instance = Instantiate (toInstantiate);
								instance.transform.position = obj.transform.position;
								Destroy (obj);
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
								GameObject obj = GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_South").gameObject;
								GameObject toInstantiate;
								int rand = Random.Range (1, 4);
								if (rand == 1) {
									toInstantiate = bad1;
								} else if (rand == 2) {
									toInstantiate = bad2;
								} else if (rand == 3) {
									toInstantiate = bad3;
								} else {
									toInstantiate = bad3;
								}
								GameObject instance = Instantiate (toInstantiate);
								instance.transform.position = obj.transform.position;
								Destroy (obj);
							}
							if (GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North") != null) {
								GameObject obj = GameObject.Find ("False_" + i).gameObject.transform.Find ("Maze Cell " + k + ", " + j).gameObject.transform.Find ("Maze Wall(Clone)_North").gameObject;
								GameObject toInstantiate;
								int rand = Random.Range (1, 4);
								if (rand == 1) {
									toInstantiate = good1;
								} else if (rand == 2) {
									toInstantiate = good2;
								} else if (rand == 3) {
									toInstantiate = good3;
								} else {
									toInstantiate = good3;
								}
								GameObject instance = Instantiate (toInstantiate);
								instance.transform.position = obj.transform.position;
								Destroy (obj);
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