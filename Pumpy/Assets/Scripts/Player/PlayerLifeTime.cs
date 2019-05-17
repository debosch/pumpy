using UnityEngine;

public class PlayerLifeTime : MonoBehaviour
{
    private static float _lifeTime;

    public static float LifeTime
    {
        get
        {
            return _lifeTime;
        }

        set
        {
            _lifeTime = value;
        }
    }

    private float currentLifeTime = 0f;

    private void Start()
    {
        _lifeTime = 10f;
    }

    private void Update()
    {
        if (PlayerControl.Instance.Alive)
        {
            _lifeTime -= Time.deltaTime;
            currentLifeTime += Time.deltaTime;

            if (currentLifeTime > PlayerPrefs.GetFloat("HighScore", 0))
                PlayerPrefs.SetFloat("HighScore", currentLifeTime);

            if (_lifeTime <= 0)
                PlayerControl.Instance.Alive = false;
        }
    }
}
