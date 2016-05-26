using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {
    public Move MoveScript;
    Animator anim;
	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (MoveScript.isWalking == true)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
	}
}
