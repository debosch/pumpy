using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private void Update()
    {
        if (!PlayerControl.Instance.Alive)
            Invoke("Restart", 3f);
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level0");
    }
}
