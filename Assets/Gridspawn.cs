using UnityEngine;
using System.Collections;

public class Gridspawn : MonoBehaviour {

	public GameObject objectToSpawn;
	public GameObject objectToCop;

	public int numObjectX = 1;
	public int numObjectY = 1;

	void Start () {

		for (int x=0; x<numObjectX; x++) {
			for(int y=0; y<numObjectY; y++){
				Instantiate(objectToSpawn, transform.position+transform.right*x+transform.up*y, Quaternion.identity);
			}
		}

		for (int x=-1; x<numObjectX+1; x++) {
			for(int y=-1; y<numObjectY+1; y++){
				Instantiate(objectToCop, transform.position+transform.right*x+transform.up*y, Quaternion.identity);
			}
		}
	
	}
	

	void Update () {
	
	}
}
