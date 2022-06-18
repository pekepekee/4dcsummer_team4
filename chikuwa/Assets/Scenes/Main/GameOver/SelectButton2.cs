using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectButton2 : MonoBehaviour
{
    [SerializeField] private AudioClip choose;

    [SerializeField] private AudioClip down;

    public void ButtonChose()
    {
        GetComponent<AudioSource>().PlayOneShot(choose);
    }

    private void Retry()
    {
        SceneManager.LoadScene("InGame");
    }

    private void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void ClickRetryGame()
    {
        GetComponent<AudioSource>().PlayOneShot(down);
        Invoke("Retry", 1f);
    }

    public void ClickTitleGame()
    {
        GetComponent<AudioSource>().PlayOneShot(down);
        Invoke("Title", 1f);
    }
}

