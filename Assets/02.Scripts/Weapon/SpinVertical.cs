using UnityEngine;

public class SpinVertical : MonoBehaviour
{
    [SerializeField] private float _spinSpeed = 1080.0f;

    private void Update()
    {
        transform.Rotate(0, 0, _spinSpeed * Time.deltaTime);
    }
}
