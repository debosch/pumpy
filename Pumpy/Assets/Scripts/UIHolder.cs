using UnityEngine;
using UnityEngine.UI;

public class UIHolder : MonoBehaviour
{
    [SerializeField] private Text lifeTime;
    [SerializeField] private Text highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    private void Update()
    {
        var currentTime = PlayerLifeTime.LifeTime;

        if (currentTime >= 0)
        {
            string timeLeft = string.Format("Time remaining: {0:0.0}", currentTime);
            string highScoreText = string.Format("High score: {0:0.0} sec", PlayerPrefs.GetFloat("HighScore"));
            lifeTime.text = timeLeft;
            highScore.text = highScoreText;
        }
    }
}
