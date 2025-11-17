using UnityEngine;

public class BackgroundScoller : MonoBehaviour
{
    private static BackgroundScoller _instance;
    public static BackgroundScoller Instance => _instance;

    [SerializeField] private GameObject[] _backgrounds;
    private BackgroundScroll[] _scrolls;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        SetBackgroundScrolls();
    }

    private void SetBackgroundScrolls()
    {
        _scrolls = new BackgroundScroll[_backgrounds.Length];
        for(int i = 0; i < _backgrounds.Length; i++)
        {
            _scrolls[i] = _backgrounds[i].GetComponent<BackgroundScroll>();
        }
    }

    public void UpdateBackground(Vector2 direction)
    {
        foreach (var scroll in _scrolls)
        {
            scroll.UpdateOffset(direction);
        }
    }
}
