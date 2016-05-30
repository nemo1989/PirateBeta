using UnityEngine;
using System.Collections;

public class BunnyController : MonoBehaviour {
	public static int TotaLBunnies=0;
	public static int deadbunny;
	public GameObject[] Bunnies;
	public GameObject voidy;
	// Use this for initialization
	void Start () {

		foreach (GameObject B in Bunnies) {
		
			B.SetActive(false);
			TotaLBunnies++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Bunnies [0] == null) {
		
			deadbunny=1;
			Bunnies [0] =voidy;
		}
		if (Bunnies [1] == null) {
			
			deadbunny=2;
			Bunnies [1] =voidy;
		}
		if (Bunnies [2] == null) {

			deadbunny=3;
			Bunnies [2] =voidy;
		}
		
		if (Bunnies [3] == null) {
			
			deadbunny=4;
			Bunnies [3] =voidy;
		}
		if (Bunnies [4] == null) {
			
			deadbunny=5;
			Bunnies [4] =voidy;
		}
		if (Bunnies [5] == null) {
			
			deadbunny=6;
			Bunnies [5] =voidy;
		}





	}
}
