using UnityEngine;
using System.Collections;

public class UIPause : MonoBehaviour {
    public GameObject pauseBacground; // Assign in inspector
    public GameObject[] ObjectShow;
    private bool isShowing;
	// Use this for initialization
	void Start () {
        pauseBacground.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void PauseUIScreen()
    {

        {
            pauseBacground.SetActive(true);
            Time.timeScale = 0;
            foreach (GameObject objects in ObjectShow)
            {
                objects.SetActive(false);
            }
        }
    }
    public void ResumeUIScreen()
    {

        {
            pauseBacground.SetActive(false);
            Time.timeScale = 1;
            foreach (GameObject objects in ObjectShow)
            {
                objects.SetActive(true);
            }
        }
    }
    public void levelSelectScreen()
    {
        Time.timeScale = 1;
        Application.LoadLevel("LevelSelect");
    }
}
