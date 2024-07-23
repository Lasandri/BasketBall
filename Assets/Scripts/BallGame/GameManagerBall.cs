using UnityEngine;
using UnityEngine.UI;

public class GameManagerBall : MonoBehaviour
{
    public GameObject Ball;
    public GameObject LeftHoop;
    public GameObject RightHoop;

    private int score;  // Local score variable
    int hoopDirection = -1; //left = -1, right = 1

    public Text ScoreText;

    private GameplayManager gameplayManager;

    private void Start()
    {
        LeftHoop.SetActive(true);
        RightHoop.SetActive(false);

        gameplayManager = FindObjectOfType<GameplayManager>();
        if (gameplayManager != null)
        {
            score = gameplayManager.GetScore();
        }
        ScoreText.text = score.ToString();
    }

    public void PlayerScored()
    {
        score += 1;
        ScoreText.text = score.ToString();

        if (gameplayManager != null)
        {
            gameplayManager.UpdateScore(score);
        }

        ChangeDirection();
    }

    void ChangeDirection()
    {
        hoopDirection *= -1;

        if (hoopDirection == 1)
        {
            LeftHoop.SetActive(false);
            RightHoop.SetActive(true);
        }
        else if (hoopDirection == -1)
        {
            LeftHoop.SetActive(true);
            RightHoop.SetActive(false);
        }
    }
}


