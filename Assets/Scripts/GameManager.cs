using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlaerControl thePlayer;
    private Vector3 playerStartpoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DethManu theDethScreen;

    public BackGroundScript theBackGroundScript;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint =platformGenerator.position;
        playerStartpoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        theBackGroundScript = FindObjectOfType<BackGroundScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        // StartCoroutine("RestartGameCo");
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        theDethScreen.gameObject.SetActive(true);

        theBackGroundScript.gameObject.SetActive(false);
    }

    public void Reset()
    {
        theDethScreen.gameObject.SetActive(false);
        theBackGroundScript.gameObject.SetActive(true);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartpoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.coinsÑount = 0;
        theScoreManager.scoreIncreasing = true;

    }

    //public IEnumerator RestartGameCo()
    //{
    //    theScoreManager.scoreIncreasing = false;
    //    thePlayer.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(0.5f);

    //    platformList = FindObjectsOfType<PlatformDestroyer>();
    //    for (int i = 0; i < platformList.Length; i++)
    //    {
    //        platformList[i].gameObject.SetActive(false);
    //    }

    //    thePlayer.transform.position = playerStartpoint;
    //    platformGenerator.position = platformStartPoint;
    //    thePlayer.gameObject.SetActive(true);

    //    theScoreManager.scoreCount = 0;
    //    theScoreManager.coinsÑount = 0;
    //    theScoreManager.scoreIncreasing = true;

    //}
}
