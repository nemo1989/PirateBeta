using UnityEngine;
using System.Collections;

public class AiController : MonoBehaviour {
	public GameObject player;
    public GameController controller;
	public CharacterStates RickState;
	public BlindTerror[] BadGuy;
	public BunnyScript[] bunny;

	 GameObject[] WalkingBomb;
	Transform[] coinHolder;
	public Transform COINHOLDER;
	public int distanceForSeeRange;
  //  public Transform BotLeftNodes
	int count = 0;
		
		


	float speed =0.5f;

	Vector3 soundPosition;
	// Use this for initialization
	void Start () {
		RickState.state = CharacterStates.playerStates.WALKING;
        WalkingBomb = GameObject.FindGameObjectsWithTag("WalkingBombs");
	}
	
	// Update is called once per frame
	void Update ()
	{
         if (!controller.gameOver && !controller.win)
        {
		moveToPlayer();
        }
	

	}
	void FixedUpdate ()
	{
        if (!controller.gameOver && !controller.win)
        {
            moveToSound();
            bunnyCollectCoins();
        }
	}

	void bunnyCollectCoins()
	{

		if (COINHOLDER == null) 
		{
			return;
			
		}

		//coinHolder = COINHOLDER.GetComponentsInChildren<Transform>();
		//count = coinHolder.Length - 2;
		//Debug.Log (coinHolder.Length);

            if (count > -1) 
		{
			foreach (BunnyScript bunny1 in bunny){
			bunny1.GetComponent <AICollectCoins> ().update ();
			}
	}
	}

	void moveToPlayer()
	{
		foreach(GameObject suiBomb in WalkingBomb)
		if (suiBomb != null) 
		{
			float distanceToPlayer = Vector2.Distance (suiBomb.transform.position, player.transform.position);
		

		
			if (distanceToPlayer <= 5 && !suiBomb.gameObject.GetComponent<WalkingBombScript>().hasExploded) {
				suiBomb.transform.position = Vector2.MoveTowards (suiBomb.transform.position, new Vector3 (player.transform.position.x, suiBomb.transform.position.y, suiBomb.transform.position.z), Time.deltaTime * suiBomb.gameObject.GetComponent<WalkingBombScript>().speed);
                suiBomb.transform.position = Vector2.MoveTowards(suiBomb.transform.position, new Vector3(suiBomb.transform.position.x, player.transform.position.y, suiBomb.transform.position.z), Time.deltaTime * suiBomb.gameObject.GetComponent<WalkingBombScript>().speed);
			}
			if (distanceToPlayer <= 0.7f) 
			{
                suiBomb.gameObject.GetComponent<WalkingBombScript>().hasExploded = true;
			}

		}
	}

	void moveToSound()
	{
		if (BadGuy == null) {
			return;
		}
		foreach (BlindTerror badGuy in BadGuy)
		{

			float distanceToPlayer = Vector2.Distance (badGuy.transform.position, player.transform.position);


			if (RickState.bellPressed == true && distanceToPlayer <= distanceForSeeRange)
			{
				if(!badGuy.SetCourse)
				{
				badGuy.GetComponent <AstarAI>().Start();

				}
				badGuy.soundHeard = true;
			

				badGuy.SetCourse = true;


			}
			if(RickState.bellPressed == false)
			{
				badGuy.SetCourse = false;
			}

			if (badGuy.soundHeard)
			{

			badGuy.GetComponent <AstarAI>().update();

		
			}


		}
	}

}
