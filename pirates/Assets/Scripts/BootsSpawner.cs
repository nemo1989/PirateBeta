using UnityEngine;
using System.Collections;

public class BootsSpawner : MonoBehaviour {
	public int countdown=10;
	GameObject currentSpawnPoint;
	public GameObject[] BootSpawnPoints;
	public float deployTime=50;
	float time;
	float timeForUnspawn;
	bool Omg;
	// Use this for initialization
	void Start () {
		foreach (GameObject boots in BootSpawnPoints) 
		{
			boots.SetActive (false);
		}
	}
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		if (time >= deployTime && !Omg)
		{
			Omg=true;
			time=0;
			currentSpawnPoint=BootSpawnPoints[Random.Range(0,BootSpawnPoints.Length)];
			currentSpawnPoint.SetActive(true);
			}
		if(Omg)
		{
			timeForUnspawn+=Time.deltaTime;

		if(timeForUnspawn >= countdown)
			{
				timeForUnspawn=0;
				Omg=false;
				currentSpawnPoint.SetActive(false);

		}
	
	}

}
}