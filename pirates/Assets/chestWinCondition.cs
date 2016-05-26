using UnityEngine;
using System.Collections;

public class chestWinCondition : MonoBehaviour {
	public GameController controller;
	void OnTriggerEnter2D(Collider2D Player) {
		if (Player.gameObject.tag == "Player") {
			Debug.Log ("Level Completed");
			controller.win = true;
		}
	}
}
