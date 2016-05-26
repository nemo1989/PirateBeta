using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WalkingBombHitBox : MonoBehaviour {
	public bool isExploding;
	public bool isItCoinCollectionLevel;
	public Text playerCoinScore;
	public int CoinsReduction;
    public GameController controller;
	int totalCoins;
	bool hit =false;
    float waitTime = 0.1f;
	// Use this for initialization
    void Update() 
    {
        if (isExploding)
        {
            waitTime += waitTime * Time.deltaTime;
          
        }
    }
	void OnTriggerStay2D(Collider2D col)
	{

		if (isExploding) 
		{
           
            if (waitTime >= 0.09f)
            {
                if (col.gameObject.tag == "Player" && isItCoinCollectionLevel && !hit)
                {
                    hit = true;
                    Debug.Log("playerCoinScore is WheelHit");
                    col.gameObject.GetComponent<CoinCollection>().moneyReduction(CoinsReduction);
                    

                }
                if (col.gameObject.tag == "Player" && !isItCoinCollectionLevel )
                {
                    hit = true;

                    controller.gameOver = true;


                }
            }
		
		}
	}
}
