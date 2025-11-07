using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void TitleMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameClearTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void GameClearMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameOverTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void GameOverMain()
    {
        SceneManager.LoadScene("Main");
    }
}
