using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIDpad : MonoBehaviour {

	public Sprite[] dpad;
	public Image pad;
	//public Sprite selectedImage;



	public void UpPressed(){
		pad.sprite = dpad[0];
		//Debug.Log ("up pressed");
	}

	public void DownPressed(){
		pad.sprite = dpad[1];;
	}
	public void RightPressed(){
		pad.sprite = dpad[2];
	}

	public void LeftPressed(){
		pad.sprite = dpad[3];
	}

	// Use this for initialization
//	void Start () {
//		Image theImage = GameObject.Find("11").GetComponent<Image>();
//		theImage.sprite =newSprite;​
//	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}
