using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance = null;
    public static ScoreManager Instance => _instance;
    private int _score = 0;
    private int _combo = 0;
    private int _maxCombo = 0;
    public int Combo => _combo;
    public int Score => _score;
    private readonly int _point = 100;
    [SerializeField] private Text _scoreTextUI;
    [SerializeField] private Text _comboTextUI;

    private Tweener _punchTween;
    private float _punchDuration = 0.1f;
    private float _punchSize = 1.5f;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        RefreshScore();
        RefreshCombo();
        SetEffect();
    }

    private void SetEffect()
    {
        _punchTween = _comboTextUI.transform
            .DOShakeScale(_punchDuration, _punchSize)
            .SetAutoKill(false)
            .Pause();
    }

    private void RefreshScore()
    {
        _scoreTextUI.text = $"Score : {_score:N0}";
    }

    private void RefreshCombo()
    {
        _comboTextUI.text = $"Combo : {_combo:N0}";
    }

    public void AddScore()
    {
        _combo += 1;
        int totalPoints = _point * _combo;
        _score += totalPoints;
        RefreshScore();
        _punchTween.Restart();
        RefreshCombo();
    }

    public void ResetCombo()
    {
        if (_combo > _maxCombo)
        {
            _maxCombo = _combo;
        }
        _combo = 0;
        RefreshCombo();
    }

    public int GetMaxCombo()
    {
        if (_combo > _maxCombo) return _combo;
        return _maxCombo;
    }
}
