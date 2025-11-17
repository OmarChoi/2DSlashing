using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private static BackgroundScroller _instance;
    public static BackgroundScroller Instance => _instance;

    [SerializeField] private BackgroundScroll[] _backgroundScrolls;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }

    public void UpdateBackground(Vector2 direction)
    {
        foreach (var scroll in _backgroundScrolls)
        {
            scroll.UpdateOffset(direction);
        }
    }
}
