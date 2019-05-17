using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    private void Update()
    {
        if (!PlayerControl.Instance.Alive)
            Invoke("Restart", 3f);

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level0");
    }
}
