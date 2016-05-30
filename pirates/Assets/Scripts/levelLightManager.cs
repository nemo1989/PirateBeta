using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class levelLightManager : MonoBehaviour {
	public GameObject light1;
	public GameObject light2;
	public GameObject light3;
	public GameObject light4;
	public GameObject light5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (switchScript.switchNumber == 1) {
			light1.SetActive(true);
		}
		if (switchScript.switchNumber == 2) {
			light2.SetActive(true);
		}
		if (switchScript.switchNumber == 3) {
			light3.SetActive(true);
		}
		if (switchScript.switchNumber == 4) {
			light4.SetActive(true);
		}
		if (switchScript.switchNumber == 5) {
			light5.SetActive(true);
		}
	}
}
