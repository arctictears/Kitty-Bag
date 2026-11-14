using Unity.VisualScripting;
using UnityEngine;

public class electricfishscript : MonoBehaviour
{
    public AudioSource electricAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 0.5f);
            electricAudioSource.Play();

        }

    }
}
