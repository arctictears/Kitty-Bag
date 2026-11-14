using UnityEngine;

public class playscript : MonoBehaviour
{
    public GameObject playScreen;
    public AudioSource BGMusic;
    public AudioSource menuMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        playScreen.SetActive(true);
    }

    // Update is called once per frame
    public void StartGame()
    {
        Time.timeScale = 1.0f;
        playScreen.SetActive(false);
        BGMusic.Play();
        menuMusic.Stop();
    }
}
