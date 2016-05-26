using UnityEngine;
using System.Collections;

public class SeeZoneCollision : MonoBehaviour {

	// Use this for initialization
  public  GameController controller;
  void Update()
  {
      transform.position = new Vector3(transform.position.x, transform.position.y, 0);
  }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
                controller.gameOver = true;
            
        }
    }
}
