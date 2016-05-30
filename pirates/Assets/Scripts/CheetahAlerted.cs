using UnityEngine;
using System.Collections;

public class CheetahAlerted : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Player")
		{
			Debug.Log ("cheetah has found me");
			CheetahGetPlayer.detectedPlayer =true;
			
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		
		if (col.gameObject.tag == "Player")
		{
			CheetahGetPlayer.detectedPlayer =false;
		}
	}
}
