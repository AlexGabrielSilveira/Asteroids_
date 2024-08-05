using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int currentScore;

    public void ScoreAdd(int points) {
        currentScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText() {
        scoreText.text = currentScore.ToString();
    }
}
