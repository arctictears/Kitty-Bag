using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenRestart : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
