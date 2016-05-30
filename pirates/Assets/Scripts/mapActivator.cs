using UnityEngine;
using System.Collections;

public class mapActivator : MonoBehaviour {

    public GameObject map;
	// Use this for initialization
	void Start () {
        map.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void pamActivatator() {
        map.SetActive(true);
    }
   public void backFromMap() {
       map.SetActive(false);
   }
}
