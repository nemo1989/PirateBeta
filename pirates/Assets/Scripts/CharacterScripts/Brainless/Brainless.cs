using UnityEngine;
using System.Collections;

public class Brainless : MonoBehaviour {

	public float speed = 0;
	public GameObject LightObject;
	Animator anim;
	float x;
	float y;
    public bool isTraped;
    public float stuckTime;
    float time;
	Rigidbody2D rigi2d;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		x = transform.position.x;
		y = transform.position.y;
		rigi2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
		if (transform.position.y > y)
		{
			WalkAnimation (0, 1, true);
			MoveUpAction();
			
		} 
		else if (transform.position.y < y) 
		{
			WalkAnimation (0, -1, true);
			MoveDownAction();
			
		} 
		else if (transform.position.x > x)
		{
			WalkAnimation (1, 0, true);
			MoveRightAction();
			
		} 
		else if (transform.position.x < x)
		{
			WalkAnimation (-1, 0, true);
			MoveLeftAction();
			
		} 
		else 
		{
			anim.SetBool("isWalking",false);
		}
		
		y = transform.position.y;
		x = transform.position.x;
        Trapped();
	}
	

	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedX", x);
		anim.SetFloat("speedY", y);
		anim.SetBool("isWalking",walking);
	}
    void Trapped()
    {
        if (isTraped)
        {
            time += Time.deltaTime;
            speed = 0;
            if (time >= stuckTime)
            {
                speed = 1;
                isTraped = false;
            }
        }
    }
	void MoveRightAction()
	{
		LightObject.transform.localPosition = new Vector3 (0.5f, 0,LightObject.transform.position.z);
	}
	void MoveLeftAction()
	{
		LightObject.transform.localPosition = new Vector3 (-0.5f, 0,LightObject.transform.position.z);
	}
	void MoveUpAction()
	{
		LightObject.transform.localPosition = new Vector3 (0, 0.5f,LightObject.transform.position.z);
	}
	void MoveDownAction()
	{
		LightObject.transform.localPosition = new Vector3 (0, -0.5f,LightObject.transform.position.z);
	}

}
