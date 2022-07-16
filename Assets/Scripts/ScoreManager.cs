using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;
    public Text textCoins;

    public float coinsÑount;

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

        scoreText.text = "Î÷êè: " + Mathf.Round (scoreCount);
        hiScoreText.text ="Ğåêîäğ: " + Mathf.Round (hiScoreCount);
        textCoins.text="Ìîíåòû: " + Mathf.Round(coinsÑount);
    } 

    public void AddCoins (int CoinToAdd)
    {
        coinsÑount += CoinToAdd;
    }
}
