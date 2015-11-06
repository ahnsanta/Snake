using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {
	
	public GameObject SnakeBit;
	float gUp = 0;
	Vector2 move = Vector2.right;
	bool born = false;

	List<Transform> tail = new List<Transform>();

	void Start () {
		InvokeRepeating("Run", 0.3f, 0.3f);
	}
			
	void Update () {

		if (Input.GetKeyDown (KeyCode.RightArrow) ) {
			move = Vector2.right;
		}
		else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			move = -Vector2.right;
		}
		else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			move = Vector2.up;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			move = -Vector2.up;
		}
		gUp += Time.deltaTime;
		if (gUp>= 2f) {
			born = true;
			gUp = 0;
		}
		
	}
	void Run(){
		transform.Translate (move);
		Vector2 v = transform.position;
		if (born) {
			GameObject g = (GameObject)Instantiate (SnakeBit, v, Quaternion.identity);
			tail.Insert (0, g.transform);
			born = false;
		}
		else if (tail.Count > 0) {
			tail.Last().position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}

	}
	void OnTriggerEnter2D (Collider2D hit){
		if (hit.gameObject.CompareTag ("Cop")) {
			Destroy(gameObject);
		}
		if (hit.name.StartsWith  ("SnakeBit")) {
			Destroy(gameObject);
		}
	}
}

