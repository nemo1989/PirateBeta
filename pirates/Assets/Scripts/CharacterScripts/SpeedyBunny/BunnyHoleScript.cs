using UnityEngine;
using System.Collections;


public class BunnyHoleScript : MonoBehaviour {
	public bool bunnySleep=true;
	public bool bunnydead=false;
	public GameObject bunny;
	//private bool check=false;
	public static bool gobunny=false;
	// Use this for initialization
	void Start () {
		bunny.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!bunnySleep && BunnyFurious_LightLevels.bunnyHome) {
			bunny.SetActive (false);
			bunnySleep = true;
		}
	}

	void OnTriggerEnter2D(Collider2D colide)
	{
		
		if (colide.gameObject.tag == "Light"&&!bunnydead)
		{
			BunnyFurious_LightLevels.bunnyHome=false;
			gobunny=true;
			bunnySleep=false;
			bunny.SetActive(true);

		}
		if (colide.gameObject.tag == "puzzleObj") {
			bunnydead = true;
		} 
	}
	void OnTriggerExit2D(Collider2D colide){

		if (colide.gameObject.tag == "puzzleObj") {
			bunnydead = false;
		} 

	}
}
