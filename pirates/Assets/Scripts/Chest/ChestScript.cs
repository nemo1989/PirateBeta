using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {
    Animator anim;
    public GameController controller;
    public bool isItLightBasedLevel;
   
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

     void Update()
    {
        if (isItLightBasedLevel)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("win"))
            {
                Destroy(this.gameObject);
                controller.win = true;
            }
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("win"))
            {
                Destroy(this.gameObject);
                controller.setWinForPuzzle();
            }
            if (controller.win)
            {
                anim.SetBool("open", true);

            }
        }
       
    }
     void OnTriggerEnter2D(Collider2D collider)
     {
         if (collider.gameObject.tag == "Player")
         {

             anim.SetBool("open", true);
         }
     }
}
