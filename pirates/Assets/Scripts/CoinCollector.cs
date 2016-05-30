using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class CoinCollector : MonoBehaviour {
	public static int coinsum;
	public Text CoinScore;
	//public BunnyScript[] bunnies;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CoinScore.text = coinsum.ToString ();
	
	}
}
