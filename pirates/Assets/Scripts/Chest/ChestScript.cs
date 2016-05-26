using UnityEngine;
using System.Collections;

public class ChestScript : MonoBehaviour {
    Animator anim;
    public GameController controller;
   
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

     void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo (0).IsName("win"))
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
