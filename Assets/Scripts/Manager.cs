using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Manager : MonoBehaviour {
	public Transform[] teleport;
 	public GameObject[] prefabs;
	private int random_prefab;
	void Start () {

		Debug.Log(prefabs);
		
		Advertisement.Show();

		random_prefab = Random.Range(0, prefabs.GetLength(0));
	
		Instantiate(prefabs[random_prefab], new Vector3(5,5,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		Advertisement.Show();
	}
}
