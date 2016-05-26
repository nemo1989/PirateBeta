using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour {
	public	int coinCount =0;
	public Text Coinscore;
	public bool isCoinCollectionOn;
	public AudioClip coinSound;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}
	void Update()
	{
		if (isCoinCollectionOn)
		{
			Coinscore.text = coinCount.ToString ();
		}
	}
	public void moneyReduction(int loseAmount)
	{
		coinCount = coinCount - loseAmount;
        if (coinCount < 0)
        {
            coinCount = 0;
        }
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Coin")
		{
			Destroy (col.gameObject);
			coinCount++;
			source.PlayOneShot(coinSound,0.05f);
		}
	}
}
