using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {
	public GameObject[] bunnyTalk;
	public BunnyScript[] bunnies;
	int state;
	// Use this for initialization
	void Start () {
		foreach (GameObject text in bunnyTalk) {
		
			text.SetActive(false);
		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (BunnyController.deadbunny == 1) {
			bunnyTalk[0].SetActive(true);
			//StartCoroutine(WaitAlittle(bunnyTalk[0]));
			BunnyController.deadbunny=0;
		}
		else if (BunnyController.deadbunny == 2) {
			bunnyTalk[1].SetActive(true);
		//	StartCoroutine(WaitAlittle(bunnyTalk[1]));
			BunnyController.deadbunny=0;
		}
		else if (BunnyController.deadbunny == 3) {
			bunnyTalk[2].SetActive(true);
			//StartCoroutine(WaitAlittle(bunnyTalk[2]));
			BunnyController.deadbunny=0;

	}
		else if (BunnyController.deadbunny == 4) {
			bunnyTalk[2].SetActive(true);
			//StartCoroutine(WaitAlittle(bunnyTalk[3]));
			BunnyController.deadbunny=0;
			
		}
		else if (BunnyController.deadbunny == 5) {
			bunnyTalk[2].SetActive(true);
			//StartCoroutine(WaitAlittle(bunnyTalk[4]));
			BunnyController.deadbunny=0;
			
		}
		else if (BunnyController.deadbunny == 6) {
			bunnyTalk[2].SetActive(true);
			//StartCoroutine(WaitAlittle(bunnyTalk[5]));
			BunnyController.deadbunny=0;
			
		}
}
//	IEnumerator WaitAlittle(GameObject v){
//		yield return new WaitForSeconds (3f);
//		v.SetActive (false);
//	
//	
//	}
	public void OkButton(){

		foreach (GameObject text in bunnyTalk) {
			
			text.SetActive(false);
			
		}


	}
}