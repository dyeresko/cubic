using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score;

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
