using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _scoreInDeadMenuText;

    private float _timer = 0f;
    private float _timerForMoreScore = 0f;
    public static int Scores = 0;
    public static int ScoreScale = 0;
    public static bool IsPaused = false;

    private void Awake()
    {
        Scores = 0;
        IsPaused = false;
        ScoreScale = PlayerPrefs.GetInt("ScoreScale");
    }

    private void FixedUpdate()
    {
        if (!IsPaused)
        {
            _timerForMoreScore += Time.fixedDeltaTime;
            if (_timerForMoreScore > 2f && ScoreScale > 0)
            {
                Scores += ScoreScale;
                _scoreText.text = Scores.ToString();
                _timerForMoreScore = 0f;
            }

            _timer += Time.fixedDeltaTime;
            if (_timer > 0.4f)
            {
                Scores++;
                _scoreText.text = Scores.ToString();
                _timer = 0f;
            }
        }
    }

    public void ShowScore()
    {
        _scoreInDeadMenuText.text = Scores.ToString();

        if (PlayerPrefs.GetInt("BestScore") < Scores)
        {
            _bestScoreText.text = Scores.ToString();
            PlayerPrefs.SetInt("BestScore", Scores);
            YG.YandexGame.NewLeaderboardScores("Leaders", PlayerPrefs.GetInt("BestScore"));
        }
        else
            _bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }

    public static void KillEnemy()
    {
        Scores += 10;
    }
}
