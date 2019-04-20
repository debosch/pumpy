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

    private bool start = false;

    private void Start()
    {
        _lifeTime = 10f;
    }

    private void Update()
    {

        if (PlayerControl.Instance.Alive)
        {
            _lifeTime -= Time.deltaTime;

            if (_lifeTime <= 0)
                PlayerControl.Instance.Alive = false;
        }
    }
}
