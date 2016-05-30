using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
    int bombTimer=10;
    
    public bool hasHitMirror;
     float time;
    Animator  anim;
    CircleCollider2D circle2d;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        circle2d = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
       
        time += Time.deltaTime;
        if(time > bombTimer )
        {
            anim.SetBool("isExploding", true);
            if (!hasHitMirror)
            {
                circle2d.enabled = true;

            }
            if ( anim.GetCurrentAnimatorStateInfo(0).IsName("Destroy"))
            {
                Destroy(this.gameObject);
            }
        }
	
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Mirror")
        {
            collider.gameObject.GetComponent<MirrorScript>().RotateMirror();
            hasHitMirror = true;
        }
    }

    public void BombSetTimer5() {
        bombTimer = 5;
    }
    public void BombSetTimer10()
    {
        bombTimer = 10;
    }
}
