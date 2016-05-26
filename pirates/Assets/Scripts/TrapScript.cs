using UnityEngine;
using System.Collections;

public class TrapScript : MonoBehaviour {

	// Use this for initialization
    Animator anim;
	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (anim.GetNextAnimatorStateInfo(0).IsName("Destroy"))
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Brainless")
        {
            anim.SetBool("hasEnteredTrap", true);
            col.gameObject.GetComponent<Brainless>().isTraped = true;
           
        }
    }
}
