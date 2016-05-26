using UnityEngine;
using System.Collections;

public class InGameLeaves : MonoBehaviour {
    public Rigidbody2D leafSpring;
    public Rigidbody2D leafSpring2;

    public Rigidbody2D leafSummer;
    public Rigidbody2D leafSummer2;

    public Rigidbody2D leafAutum;
    public Rigidbody2D leafAutum2;

    public Rigidbody2D leafWinter;
    public Rigidbody2D leafWinter2;
    public int rangePosition1;
    public int rangePosition2;

   

    float time = 0;
   public int whichLeaves = 0;
    public float spawnTime;
    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        switch (whichLeaves)
        {
            case 0:
                SpringFall(time);
                break;
            case 1:
                SummerFall(time);
                break;

            case 2:
                AutumFall(time);

                break;

            case 3:
                WinterFall(time);

                break;
            case 4:
                ShipFall(time);

                break;
        }
    }
    void SpringFall(float timer)
    {
        if (time >= spawnTime)
        {
            Rigidbody2D LeafInstance;
            int randomLeaf = Random.Range(0, 2);
            if (randomLeaf == 1)
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafSpring2);
            }


            else
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafSpring);
            }

            time = 0;
            int xPosition = Random.Range(-10, 10);
            LeafInstance.transform.position = new Vector2(xPosition, 10);

        }
    }
    void SummerFall(float timer)
    {
        if (time >= spawnTime)
        {
            Rigidbody2D LeafInstance;
            int randomLeaf = Random.Range(0, 2);
            if (randomLeaf == 1)
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafSummer2);
            }


            else
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafSummer);
            }

            time = 0;
            int xPosition = Random.Range(-10, 10);
            LeafInstance.transform.position = new Vector2(xPosition, 10);

        }
    }
    void AutumFall(float timer)
    {
        if (time >= spawnTime)
        {
            Rigidbody2D LeafInstance;
            int randomLeaf = Random.Range(0, 2);
            if (randomLeaf == 1)
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafAutum2);
            }


            else
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafAutum);
            }

            time = 0;
            int xPosition = Random.Range(-4, 15);
            LeafInstance.transform.position = new Vector2(xPosition, 1);

        }
    }
    void WinterFall(float timer)
    {
        if (time >= spawnTime)
        {
            Rigidbody2D LeafInstance;
            int randomLeaf = Random.Range(0, 2);
            if (randomLeaf == 1)
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafWinter2);
            }


            else
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafWinter);
            }

            time = 0;
            int xPosition = Random.Range(rangePosition1, rangePosition2);
            LeafInstance.transform.position = new Vector2(xPosition, 1);

        }
    }
    void ShipFall(float timer)
    {
        if (time >= spawnTime)
        {
            Rigidbody2D LeafInstance;
            int randomLeaf = Random.Range(0, 2);
            if (randomLeaf == 1)
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafSpring2);
            }


            else
            {
                LeafInstance = (Rigidbody2D)Instantiate(leafSpring);
            }

            time = 0;
            int xPosition = Random.Range(-10, 10);
            LeafInstance.transform.position = new Vector2(xPosition, 10);

        }
    }
}
