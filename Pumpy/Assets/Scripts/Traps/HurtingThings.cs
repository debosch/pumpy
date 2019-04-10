using UnityEngine;

public class HurtingThings : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerControl.Instance.Alive = false;
        }
    }
}
