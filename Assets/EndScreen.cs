using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalWinText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void UpdateWinText()
    {
        finalWinText.text = "Congratulations!\nYou have managed to score " + scoreKeeper.CalculateScore() + "%";
    }

    
}
