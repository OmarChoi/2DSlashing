using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Text _scoreTextUI;
    [SerializeField] Text _maxComboTextUI;

    private void OnEnable()
    {
        SetScoreText();
        SetComboText();
    }

    private void SetScoreText()
    {
        int score = ScoreManager.Instance.Score;
        _scoreTextUI.text = $"Score : {score:N0}";
    }

    private void SetComboText()
    {
        int maxCombo = ScoreManager.Instance.GetMaxCombo();
        _maxComboTextUI.text = $"Max Combo : {maxCombo:N0}";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
