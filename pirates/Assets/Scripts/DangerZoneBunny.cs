using UnityEngine;
using System.Collections;

public class DangerZoneBunny : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            LeaveMeAlone.BunnySpeed = 2.2f;

        }
    }
}
