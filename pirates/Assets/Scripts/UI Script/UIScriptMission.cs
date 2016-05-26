using UnityEngine;
using System.Collections;

public class UIScriptMission : MonoBehaviour {

	public GameObject menu; // Assign in inspector
	public GameObject[] ObjectShow;
    public GameObject levelComplete;
    public GameObject MissionFailed;
	private bool isShowing;
	void Start ()
	{
		Time.timeScale = 0;
		foreach (GameObject objects in ObjectShow) 
		{
			objects.SetActive (false);
		}
        levelComplete.SetActive(false);
        MissionFailed.SetActive(false);
	}
	public void removeUIScreen () 
	{

		{
            menu.SetActive(false);

			Time.timeScale = 1;
			foreach (GameObject objects in ObjectShow) 
			{
				objects.SetActive (true);
			}
		}
	}
  
}

