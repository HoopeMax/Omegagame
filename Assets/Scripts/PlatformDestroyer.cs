using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject PlatformDestroyerPoint;


    // Start is called before the first frame update
    void Start()
    {
        PlatformDestroyerPoint = GameObject.Find("PlatformDestroyerPoint");

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < PlatformDestroyerPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
