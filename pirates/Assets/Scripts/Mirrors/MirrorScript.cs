using UnityEngine;
using System.Collections;

public class MirrorScript : MonoBehaviour {
    public bool showLight;
    public GameObject lightRay;
    public GameObject shutRayLightFormOtherMirrors;
    public bool turnAntiClockWise;
   
	// Use this for initialization
	void Start ()
    {
        showLight = false;
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        checkIfLightHasHitMirror();
	}
    void checkIfLightHasHitMirror()
    {
        if (showLight)
        {
            lightRay.SetActive(true);
            shutRayLightFormOtherMirrors.SetActive(false);
            
        }
        else
        {
            
            lightRay.SetActive(false);
            shutRayLightFormOtherMirrors.SetActive(true);
        }
    
    }
  public  void RotateMirror()
    {
        if (!turnAntiClockWise)
        {
            transform.Rotate(0, 0, 90);
        }
        else
        {
            transform.Rotate(0, 0, -90);
        }



    }
}
