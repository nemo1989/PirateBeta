using UnityEngine;
using System.Collections;

public class RetryScript : MonoBehaviour {
   
	// Use this for initialization
    public void RetryLevelSpring(int level)
    {
        switch (level)
        {
            case 1:
                print("load Scene 1");
                Application.LoadLevel("SpringLevel1");
                break;
            case 2:
                print("load Scenec 2");
                Application.LoadLevel("SpringLevel2");
                break;

            case 3:
                print("load Scenec 3");
                Application.LoadLevel("SpringLevel3");
                break;
           
        }
       
       
    }
    public void RetryLevelSummer(int level)
    {
        switch (level)
        {
            case 1:
                print("load Scene 1");
                Application.LoadLevel("SummerLevel1");
                break;
           

        }


    }
    public void RetryLevelAutum(int level)
    {
        switch (level)
        {
            case 1:
                print("load Scene 1");
                Application.LoadLevel("AutumLevel1");
                break;
            case 2:
                print("load Scene 2");
                Application.LoadLevel("AutumLevel2");
                break;
           

        }


    }
    public void RetryLevelWinter(int level)
    {
        switch (level)
        {
            case 1:
                print("load Scene 1");
                Application.LoadLevel("WinterLevel1");
                break;
          

        }


    }
    public void RetryLevelShip(int level)
    {
        switch (level)
        {
            case 1:
                print("load Scene 1");
                Application.LoadLevel("ShipLevel1");
                break;
            case 2:
                print("load Scenec 2");
                Application.LoadLevel("WaterLevel1");
                break;
          

        }


    }
}
