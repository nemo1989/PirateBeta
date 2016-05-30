using UnityEngine;
using System.Collections;

public class PortalWeapon : MonoBehaviour {
	public GameObject blueBullet;
	public GameObject yellowBullet;
	public static bool blueDeployed;
	public static bool yellowDeployed;
	public static int gatesSpawned=0;
	bool once1=false;
	bool once2=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (!blueDeployed) {
			if (Input.GetKey (KeyCode.L)) {
				if(!once1){
				gatesSpawned++;
					once1=true;
				}
				GameObject bBullet;
				blueDeployed=true;
				bBullet = (GameObject)Instantiate (blueBullet);
				if (bBullet != null) {
					bBullet.transform.position = transform.position;
				} else
					Debug.Log ("oho");
			}
		}
		if (!yellowDeployed) {
		if(Input.GetKey(KeyCode.K)){
				if(!once2){
					gatesSpawned++;
					once2=true;
				}
				GameObject yBullet;
					yellowDeployed=true;
					yBullet = (GameObject)Instantiate (yellowBullet);
					if (yBullet != null) {
						yBullet.transform.position = transform.position;
					} else
						Debug.Log ("oho");
				}

			
			
		}

	}
	//public void PortalBluePressed(){



	//}
}
