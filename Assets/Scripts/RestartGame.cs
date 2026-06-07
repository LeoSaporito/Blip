using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
