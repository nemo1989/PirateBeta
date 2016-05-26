using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour {
     enum moveDirection { LEFT, RIGHT, MIDDLE };
     moveDirection panelDirection = moveDirection.MIDDLE;
     moveDirection backgroundDirection = moveDirection.MIDDLE;

    public GameObject[] BackgroundImages;
    public GameObject[] Panel;

    public Button[] stageButtons;
    public Button rightButton;
    public Button leftButton;
    bool hasCheckedStage;
   public int counter = 0;
    int backgroundcounter = 0;
    public float xRight;
    public float xLeft;
    public float middle;
    bool hasReachedDestination;
    public float xRightBackground;
    public float xLeftBackground;
    public float middleBackground;


	// Use this for initialization
	void Start () 
    {
        Debug.Log(Panel.Length);
	}
	
	// Update is called once per frame
	void Update () 
    {
        PanelMoveLeftOrRight();
     //   BackgroundMoveLeftOrRight();
        if (hasCheckedStage)
        {
            HilightButtons();
            hasCheckedStage = false;
        }
      
        
	}
    void PanelMoveLeftOrRight()
    {
        
        
            if (panelDirection == moveDirection.RIGHT && counter < 5)
            {
                if (!hasReachedDestination)
                {
                    Panel[counter].transform.localPosition = Vector2.MoveTowards(Panel[counter].transform.localPosition, new Vector2(xLeft, 0), 100);
                    BackgroundImages[counter].transform.position =  Vector2.MoveTowards( BackgroundImages[counter].transform.position,new Vector2 (xLeftBackground, 0),1);

                    if (Panel[counter].transform.localPosition == new Vector3(xLeft, 0, 0) && BackgroundImages[counter].transform.position == new Vector3(xLeftBackground,0) )
                    {
                        
                        
                            counter++;
                            hasReachedDestination = true;
                        
                    }
                }

                if (hasReachedDestination)
                {
                    Panel[counter].transform.localPosition =Vector2.MoveTowards(Panel[counter].transform.localPosition, new Vector2(middle, 0),100);
                    BackgroundImages[counter].transform.position = Vector2.MoveTowards(BackgroundImages[counter].transform.position, new Vector2(middleBackground, 0), 1);
                }
                if (Panel[counter].transform.localPosition == new Vector3(middle, 0, 0) && BackgroundImages[counter].transform.position == new Vector3(middleBackground, 0, 0))
                {
                    hasReachedDestination = false;
                    hasCheckedStage = true;
                    panelDirection = moveDirection.MIDDLE;
                }
               
            }
        


            if (panelDirection == moveDirection.LEFT && counter >= 0 )
            {
                if (!hasReachedDestination)
                {
                    Panel[counter].transform.localPosition = Vector2.MoveTowards(Panel[counter].transform.localPosition, new Vector2(xRight, 0), 100);
                    BackgroundImages[counter].transform.position =  Vector2.MoveTowards( BackgroundImages[counter].transform.position,new Vector2 (xRightBackground, 0),1);



                    if (Panel[counter].transform.localPosition == new Vector3(xRight, 0, 0) && BackgroundImages[counter].transform.position == new Vector3(xRightBackground, 0,0))
                    {
                        counter--;
                        hasReachedDestination = true;
                    }
                }

                if (hasReachedDestination)
                {
                    Panel[counter].transform.localPosition = Vector2.MoveTowards(Panel[counter].transform.localPosition, new Vector2(middle, 0), 100);
                    BackgroundImages[counter].transform.position = Vector2.MoveTowards(BackgroundImages[counter].transform.position, new Vector2(middleBackground, 0), 1);

                    if (Panel[counter].transform.localPosition == new Vector3(middle, 0, 0) && BackgroundImages[counter].transform.position == new Vector3(middleBackground, 0,0))
                    {
                        hasReachedDestination = false;
                        hasCheckedStage = true;
                        panelDirection = moveDirection.MIDDLE;
                    }
                }
              
            }
            if (counter == Panel.Length -1)
            {
                rightButton.enabled = false;
                rightButton.interactable = false;
                rightButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);

            }
            else
            {
                rightButton.enabled = true;
                rightButton.interactable = true;
                rightButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
            }
            if (counter == 0)
            {
                leftButton.enabled = false;
                leftButton.interactable = false;
                leftButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);

            }
            else
            {
               leftButton.enabled = true;
               leftButton.interactable = true;
               leftButton.GetComponentInChildren<CanvasRenderer>().SetAlpha(1);
            }
        
   //   panelDirection = moveDirection.MIDDLE;
    
    }
  /*  void BackgroundMoveLeftOrRight()
    {


        if (backgroundDirection == moveDirection.RIGHT && counter < BackgroundImages.Length -1  )
        {
            BackgroundImages[counter].transform.position = new Vector2(xLeftBackground, 0);
            backgroundcounter++;
            BackgroundImages[counter].transform.position = new Vector2(middleBackground, 0);

        }


        if (backgroundDirection == moveDirection.LEFT && backgroundcounter > 0)
        {
            BackgroundImages[backgroundcounter].transform.localPosition = new Vector2(xRightBacground, 0);
            backgroundcounter--;
            BackgroundImages[backgroundcounter].transform.localPosition = new Vector2(middleBackground, 0);
        }
      

        backgroundDirection = moveDirection.MIDDLE;

    }*/
    public void moveRight()
    { 
        panelDirection = moveDirection.RIGHT;

        backgroundDirection = moveDirection.RIGHT;
    }
    public void moveLeft()
    {
        panelDirection = moveDirection.LEFT;
        backgroundDirection = moveDirection.LEFT;
        
    }
    void HilightButtons()
    {
        for (int i = 0; i < stageButtons.Length; i++)
        {
            stageButtons[i].interactable = true;
        }
        switch (counter)
        {
               
            case 0:
                stageButtons[counter].interactable = false;
                break;
            case 1:
                stageButtons[counter].interactable = false;
                break;
            case 2:
                stageButtons[counter].interactable = false;
                break;
            case 3:
                stageButtons[counter].interactable = false;
                break;
            case 4:
                stageButtons[counter].interactable = false;
                break;

        }
    }
}
