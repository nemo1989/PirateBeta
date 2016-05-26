using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {
    float time =1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += time * Time.deltaTime;
        Debug.Log(time);
        if (time > 10)
        {
            Application.LoadLevel("Main Menu");
            
            time = 0;
        }
	}
}
