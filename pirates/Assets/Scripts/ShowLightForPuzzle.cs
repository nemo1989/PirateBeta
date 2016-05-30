using UnityEngine;
using System.Collections;

public class ShowLightForPuzzle : MonoBehaviour {
    GameObject gameController;
   public GameObject light;
	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameCon");
	}
	
	// Update is called once per frame
	void Update () {

        if (gameController.gameObject.GetComponent<GameController>().ShowLight == true)
        {
            light.SetActive(true);
        }
	}
}
