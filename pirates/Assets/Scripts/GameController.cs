using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public switchScript [] switchObject;
    public bool gameOver;
    public bool win;
    public GameObject winObject;
    public GameObject MissionFailedObject;
    public GameObject Controls;
    public bool DoesItCompleteLevelForPuzzle = true;
    public bool ShowLight = false;
	public bool allSwithdown = true;
    public bool isItACoinLevel;
    bool hasDisplayedWinLose;
    public bool isInLight;
    float delay = 0;
    float checkTimeoutOfLight;
   public bool IsItPuzzleLevel;
   public bool isItStayIntheLightLevel;
	public bool isItBlindLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        CheckAllSwitchAreDown();
        LevelComplete();
        LevelFailed();
        if (isItStayIntheLightLevel)
        {
            checkIfPlayerHasLeftLight();
        }
        if (LightDestroyer.Checkpoint) {
        
        }
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
                ShowLight = true;
            }
            if (allSwithdown && DoesItCompleteLevelForPuzzle)
            {
                win = true;
               
            }
        }
    }
    void checkIfPlayerHasLeftLight()
    {
        if (!isInLight)
        {
            checkTimeoutOfLight += Time.deltaTime;
            if (checkTimeoutOfLight > 0.1)
            {
                gameOver = true;
            }
        }
        else
        {
            checkTimeoutOfLight = 0;
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
                if(delay >= 0.1)
                { 
                MissionFailedObject.SetActive(true);
                Time.timeScale = 0;
                }
               
            }
        }
    
    }
}

