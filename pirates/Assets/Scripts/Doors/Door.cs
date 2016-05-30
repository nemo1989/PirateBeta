using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	Animator anim;
	BoxCollider2D b2D;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		b2D = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	gameObject.GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
	}
public	void OpenDoor()
	{
		anim.SetBool ("Open", true);

	}
public	void CloseDoor()
	{
		anim.SetBool ("Open", false);

	}
	public void RemoveCollision()
	{
		b2D.enabled = false;

	}
	public void EnableCollision()
	{
		b2D.enabled = true;
			
	}
}
