using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    private Material _material;
    [SerializeField] private float _speed;
    private void Awake()
    {
        _material = this.GetComponent<Image>().material;
    }

    public void UpdateOffset(Vector2 direction)
    {
        Vector2 offset = _material.mainTextureOffset;

        offset += direction * _speed * Time.deltaTime;
        offset.x = Mathf.Repeat(offset.x, 1.0f);

        _material.mainTextureOffset = offset;
    }
}
