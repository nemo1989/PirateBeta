using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public switchScript [] switchObject;
    public bool gameOver;
    public bool win;
    public GameObject winObject;
    public GameObject MissionFailedObject;
    public GameObject Controls;
	bool allSwithdown = true;
    bool hasDisplayedWinLose;
    float delay = 0; 
   public bool IsItPuzzleLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        CheckAllSwitchAreDown();
        LevelComplete();
        LevelFailed();

	}


    void CheckAllSwitchAreDown()
    {
        if (switchObject.Length > 0)
        {
            allSwithdown = true;
            for (int i = 0; i < switchObject.Length; i++)
            {
                if (!switchObject[i].isSwitchDown)
                {
                    allSwithdown = false;
                    break; //this "quits" the for loop, you don't need to check the rest of the items if you already found one that's not active
                }
            }
            if (allSwithdown)
            {
                win = true;
               
            }
        }
    }
    void LevelComplete()
    {
        if (win)
        {

            if (!hasDisplayedWinLose)
            {
              //  if (!IsItPuzzleLevel)
             //   {
                    winObject.SetActive(true);
                   
                    Time.timeScale = 0;
                    hasDisplayedWinLose = true;
                }
                else
                {

                    Controls.SetActive(false);
                }
                
            }
         

        
    }
    public void setWinForPuzzle()
    {
        if (!hasDisplayedWinLose)
        {
            winObject.SetActive(true);
            hasDisplayedWinLose = true;
        }
    }
    void LevelFailed()
    {
        if (gameOver)
        {
            if (!hasDisplayedWinLose)
            {
               
                Controls.SetActive(false);
                delay += Time.deltaTime;
                if(delay >= 1)
                { 
                MissionFailedObject.SetActive(true);
                Time.timeScale = 0;
                }
               
            }
        }
    
    }
}

