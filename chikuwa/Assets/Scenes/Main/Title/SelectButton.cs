using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectButton : MonoBehaviour 
{
    [SerializeField] private AudioClip choose;

    [SerializeField] private AudioClip down;

    public void ButtonChose()
    {
        GetComponent<AudioSource>().PlayOneShot(choose);
    }

    private void Ingame()
    {
        SceneManager.LoadScene("InGame");
    }

    private void Endgame()
    {
        ExitGame.ExitImm();
    }

    private void credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void ClickStartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(down);
        Invoke("Ingame", 1f);
    }

    public void ClickEndGame()
    {
        GetComponent<AudioSource>().PlayOneShot(down);
        Invoke("Endgame", 1f);
    }

    public void ClickShowCredit()
    {
        GetComponent<AudioSource>().PlayOneShot(down);
        Invoke("credit", 1f);
    }
}
