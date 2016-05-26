using UnityEngine;
using System.Collections;

public class CannonScript : MonoBehaviour {
	public enum Directions{UP,DOW,LEFT,RIGHT}
	public Directions face;
	public float cannonShootTime = 5;
	public GameObject cannonBall;
    public AudioClip clip;
    AudioSource source;
	float timeTrack;
    bool DoneFacingLeft;

	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
       
		timeTrack +=Time.deltaTime; 

		if(timeTrack >= cannonShootTime && face == Directions.RIGHT)
		{
            if (DoneFacingLeft == true)
            {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                DoneFacingLeft = false;
            }
            ShootAnimation(1, 0, true);
           
				GameObject projectile;
				projectile = (GameObject)Instantiate (cannonBall);
				projectile.transform.position = transform.position;
                projectile.GetComponent<CannonBallScript>().moveRight();
                PlaySound();
				timeTrack= 0;

		}
		
        else   if (timeTrack >= cannonShootTime && face == Directions.LEFT)
        {
           if(DoneFacingLeft == false)
          { 
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            DoneFacingLeft = true;
        }
           ShootAnimation(1, 0, true);
         
            GameObject projectile;
            projectile = (GameObject)Instantiate(cannonBall);
            projectile.transform.position = transform.position;
            projectile.GetComponent<CannonBallScript>().moveLeft();
            timeTrack = 0;
            PlaySound();


        }


        else if (timeTrack >= cannonShootTime && face == Directions.UP)
        {

            ShootAnimation(0, 1, true);

            GameObject projectile;
            projectile = (GameObject)Instantiate(cannonBall);
            projectile.transform.position = transform.position;
            projectile.GetComponent<CannonBallScript>().moveUp();
            timeTrack = 0;
            PlaySound();

        }
      

        else  if (timeTrack >= cannonShootTime && face == Directions.DOW)
        {
       
            ShootAnimation(0, -1, true);
            GameObject projectile;
            projectile = (GameObject)Instantiate(cannonBall);
            projectile.transform.position = transform.position;
            projectile.GetComponent<CannonBallScript>().moveDown();
            timeTrack = 0;
            PlaySound();


        }
        else
        {
            anim.SetBool("shoot", false);
        }
		
		
	}
    void ShootAnimation(float x, float y, bool shoot)
    {
        anim.SetFloat("Xaxis", x);
        anim.SetFloat("Yaxis", y);
        anim.SetBool("shoot", shoot);
    }
    void PlaySound()
    {
        source.PlayOneShot(clip, 0.3f);
    }
}
