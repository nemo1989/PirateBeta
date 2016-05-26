using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {
    public float timeLimt;
    public GameController controller;
    public Text timeText;
    public Text bunnyGuyTextScore;
    public Text playerTextScore;
    int bunnyCoinScore;
    int playerCoinScore;
    public bool IsCoinCollection;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!controller.gameOver && !controller.win)
        {
        timeLimt -= Time.deltaTime;
        timeText.text = ((int)timeLimt).ToString();
     if(timeLimt <= 0)  
             {
                 if (IsCoinCollection)
                 {
                     bunnyCoinScore = int.Parse(bunnyGuyTextScore.text);
                     playerCoinScore = int.Parse(playerTextScore.text);
                     if (playerCoinScore > bunnyCoinScore)
                     {
                         controller.win = true;
                     }
                     else
                     {
                         controller.gameOver = true;
                     }
                 }
                 else
                 {
                     controller.gameOver = true;
                 }

             }
         }
	}
}
