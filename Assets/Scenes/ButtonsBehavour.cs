using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }
    public void RePlay()
    {
        SceneManager.LoadScene(0);
    }
}
