using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text textCoins;

    public float coins�ount;

    public float scoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing; 

    // Start is called before the first frame update
    void Start()
    {
        if( PlayerPrefs.HasKey("HightScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HightScore");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > hiScoreCount)
        {
            hiScoreCount= scoreCount;
            PlayerPrefs.SetFloat("HightScore", hiScoreCount);
        }

        scoreText.text = "����: " + Mathf.Round (scoreCount);
        hiScoreText.text ="������: " + Mathf.Round (hiScoreCount);
        textCoins.text="������: " + Mathf.Round(coins�ount);
    } 

    public void AddCoins (int CoinToAdd)
    {
        coins�ount += CoinToAdd;
    }
}
