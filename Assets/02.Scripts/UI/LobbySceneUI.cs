using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneUI : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
