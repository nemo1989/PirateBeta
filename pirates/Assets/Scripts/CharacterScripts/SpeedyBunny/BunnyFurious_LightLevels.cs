using UnityEngine;
using System.Collections;

public class BunnyFurious_LightLevels : MonoBehaviour {
	public Transform annoyingMirror;
	public Transform HomeSweetHome;
	public float speed;
	public static bool bunnyHome;
	public static bool bunnyGoBackInYourWhole=false;
	public static bool MissionAccomplished=false;
	// Update is called once per frame
	void Update () {
		if (BunnyHoleScript.gobunny) {
			Debug.Log ("Bunny woke up");
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, annoyingMirror.position, step);

		}
		if (/*BunnyWhyHitMe_LightLevels.*/bunnyGoBackInYourWhole) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, HomeSweetHome.position, step);

			BunnyHoleScript.gobunny=false;
		}
		if ((transform.position == HomeSweetHome.position) && (/*BunnyWhyHitMe_LightLevels.*/bunnyGoBackInYourWhole)) {

			/*BunnyWhyHitMe_LightLevels.*/bunnyGoBackInYourWhole=false;
			bunnyHome = true;
		}


		}
	void OnTriggerEnter2D(Collider2D colide)
	{
		if (colide.gameObject.tag == "Mirror")
		{
			MissionAccomplished=true;
			BunnyHoleScript.gobunny=false;
			Debug.Log ("I hit the Mirror");
			bunnyGoBackInYourWhole=true;

			
		}
		
	}

}
