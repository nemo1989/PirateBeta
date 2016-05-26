using UnityEngine;
using System.Collections;

public class BlindTerror : MonoBehaviour {
	public float speed = 0;
	Animator anim;

	public bool soundHeard;
	public bool SetCourse;
	Rigidbody2D rigi;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		rigi = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
    void FixedUpdate()
    {
        if (rigi.velocity.y > 0.1)
        {
            WalkAnimation(0, 3, true);

        }
        else if (rigi.velocity.y < -0.1)
        {
            WalkAnimation(0, -3, true);

        }
        else if (rigi.velocity.x > 0.1)
        {
            WalkAnimation(3, 0, true);

        }
        else if (rigi.velocity.x < -0.1)
        {
            WalkAnimation(-3, 0, true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }


    }
	
	
	void WalkAnimation(float x, float y, bool walking)
	{
		anim.SetFloat("speedX", x);
		anim.SetFloat("speedY", y);
		anim.SetBool("isWalking",walking);
	}
}
