using UnityEngine;
using UnityEngine.UI;

public class UIHolder : MonoBehaviour
{
    private Text lifeTime;

    private void Start()
    {
        lifeTime = GetComponent<Text>();    
    }

    private void Update()
    {
        var currentTime = PlayerLifeTime.LifeTime;
        if (currentTime >= 0)
        {
            string timeLeft = string.Format("Time left: {0:0.0}", currentTime);
            lifeTime.text = timeLeft;
        }
    }
}
