using UnityEngine;
using System.Collections;

public class LevelSelectScript : MonoBehaviour 
{

public void LoadSceneSpring(int Scene)
	{
        switch (Scene)
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
public void LoadSceneSummer(int Scene)
{
    switch (Scene)
    {
        case 1:
            print("load Scene 1");
            Application.LoadLevel("SummerLevel1");
            break;
       

    }


}
public void LoadSceneAutum(int Scene)
{
    switch (Scene)
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
public void LoadSceneWinter(int Scene)
{
    switch (Scene)
    {
        case 1:
            print("load Scene 1");
            Application.LoadLevel("WinterLevel1");
            break;
      

    }


}
public void LoadSceneShip(int Scene)
{
    switch (Scene)
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
