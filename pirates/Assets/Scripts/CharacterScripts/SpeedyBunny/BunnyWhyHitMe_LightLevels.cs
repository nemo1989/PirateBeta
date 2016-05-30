using UnityEngine;
using System.Collections;

public class BunnyWhyHitMe_LightLevels : MonoBehaviour {
	public bool bunnyHit=false;
//	public static bool bunnyGoBackInYourWhole=false;
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
	// Update is called once per frame
	void Update () {
		if (BunnyFurious_LightLevels.MissionAccomplished) {
			transform.Rotate (0, 0, +90);
			BunnyFurious_LightLevels.MissionAccomplished=false;
		}
	}
//	void OnTriggerEnter2D(Collider2D colide)
//	{
//		
//		if (colide.gameObject.tag == "Bunny")
//		{
//			transform.Rotate(0, 0, +90);
//			Debug.Log ("mpasldskp");
//			bunnyGoBackInYourWhole=true;
//			BunnyHoleScript.gobunny=false;
//
//		}
//}
}