using UnityEngine;
//using System.Collections;
using System.Collections.Generic;
public class ThrowCoins : MonoBehaviour
{
    public GameObject Coins;
    public Transform[] CoinsPosition;
    public Transform[] moveToLocation;
    List<GameObject> coinsArray = new List<GameObject>();
    public float throwSpeed;
    public float speed;
    float time;
    bool hasReachedPosition;
    int randomPosLocation;
  
    int randomPos;
	// Use this for initialization
	void Start () 
    {
        randomPosLocation = 0;
        hasReachedPosition = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToRandomLocation();
        CreateCoin();
        MoveCoinToLocationRandomly();
        DeletCoins();
            
        
	
	}
    void CreateCoin()
    {
        
        if (coinsArray.Count < 1)
        {
            int randomIndex = Random.Range(0, CoinsPosition.Length - 1);
            randomPos = randomIndex;
            GameObject coin = Instantiate(Coins);
            coin.transform.position = transform.position;
            coinsArray.Add(coin);
        }
           
         
        
   /* coin.transform.position = transform.position;
    coin.transform.position = Vector2.MoveTowards(transform.position, CoinsPosition[randomPos].position, throwSpeed * Time.deltaTime);
     */

    }
    void MoveCoinToLocationRandomly()
    {
        foreach (GameObject C in coinsArray)
        {
            if (C != null)
            {


                C.transform.position = Vector2.MoveTowards(C.transform.position, CoinsPosition[randomPos].position, throwSpeed * Time.deltaTime);
            }
           
        }
    }
    void DeletCoins()
    {
        for (int i = 0; i < coinsArray.Count; i++)
        {
            if (coinsArray[i] == null)
            {
                coinsArray.RemoveAt(i);
            }
        }
    }
    void MoveToRandomLocation()
    {
       
        if (hasReachedPosition)
        {
            int counter = Random.Range(0, moveToLocation.Length - 1);
            randomPosLocation = counter;

             hasReachedPosition = false;
             Debug.Log("NEW LOCATION GIVEN");
        }
        transform.position = Vector2.MoveTowards(transform.position, moveToLocation[randomPosLocation].position, speed * Time.deltaTime);
        if (transform.position == moveToLocation[randomPosLocation].position)
        {
            hasReachedPosition = true;
            
        }
    }
}
