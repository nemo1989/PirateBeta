using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour
{
    public GameObject Bombs;
    public int BombsPickup;
    public int BombsInventroy;
    // Use this for initialization
    void Start()
    {
        Bombs.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            Bombs.SetActive(false);
            BombsInventroy = BombsInventroy + BombsPickup;

        }
    }
}
