using UnityEngine;
using System.Collections;

public class DarkWorld : MonoBehaviour {
	public float darkWorldTimer;
	private float timer;
	bool isInDarkWorld;
	public GameObject objectsToSetNotActiveOrActive;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		DarkWorldTimer ();
	
	}
	public void DarkWorldActive()
	{
	if (!isInDarkWorld)
		{
			transform.localRotation = Quaternion.Euler(0, 180, 0);
			timer = 0;
			isInDarkWorld = true;
			objectsToSetNotActiveOrActive.SetActive(false);
		}
	}
	private void DarkWorldTimer()
	{
		if (isInDarkWorld) 
		{
			timer +=Time.deltaTime;
			if(timer > darkWorldTimer)
			{
				transform.localRotation = Quaternion.Euler(0, 0, 0);
				isInDarkWorld = false;
				objectsToSetNotActiveOrActive.SetActive(true);
				timer = 0;
			}
		}

	}
}
