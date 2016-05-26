using UnityEngine;
using System.Collections;

public class followObjects : MonoBehaviour 
{
	public GameObject cameraTarget; // object to look at or follow
   public float smoothTime = 20f;    // time for dampen
	public bool cameraFollowX = true; // camera follows on horizontal
	public bool cameraFollowY = true; // camera follows on vertical
	public bool cameraFollowHeight = true; // camera follow CameraTarget object height
	public float cameraHeight = 2.5f; // height of camera adjustable
	public Vector2 velocity; // speed of camera movement
	public float cameraLimtLeft = 0f;
	public float cameraRight = 13f;
	public float cameraLimtTop = 0f;
	public float cameraBottom = 13f;
    public bool isItRacingGame;
    public float cameraYPosition;
	
	private Transform thisTransform; // camera Transform
	
	// Use this for initialization
	void Start()
	{
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (cameraFollowX)

		{
           
            
                thisTransform.transform.position = new Vector3(Mathf.SmoothDamp(thisTransform.position.x, cameraTarget.transform.position.x, ref velocity.x, smoothTime), thisTransform.position.y, thisTransform.position.z);
            
		}
			if(thisTransform.position.x < cameraLimtLeft )
			{
			thisTransform.transform.position = new Vector3(cameraLimtLeft,thisTransform.position.y, thisTransform.position.z);
			}
			if(thisTransform.position.x > cameraRight)
			{
			thisTransform.transform.position = new Vector3(cameraRight,thisTransform.position.y, thisTransform.position.z);
			}

		if (cameraFollowY)
		
			{
                if (isItRacingGame)
                {
                    thisTransform.transform.position = new Vector3(thisTransform.position.x, Mathf.SmoothDamp(thisTransform.position.y, cameraTarget.transform.position.y +cameraYPosition, ref velocity.y, smoothTime), thisTransform.position.z); }
                else
                {
                    thisTransform.transform.position = new Vector3(thisTransform.position.x, Mathf.SmoothDamp(thisTransform.position.y, cameraTarget.transform.position.y, ref velocity.y, smoothTime), thisTransform.position.z);
                }
			}
			if(thisTransform.position.y < cameraBottom )
			{
			thisTransform.transform.position = new Vector3(thisTransform.position.x,cameraBottom, thisTransform.position.z);
			}
			if(thisTransform.position.y > cameraLimtTop)
			{
			thisTransform.transform.position = new Vector3(thisTransform.position.x,cameraLimtTop ,thisTransform.position.z);
			}

	
	}

}