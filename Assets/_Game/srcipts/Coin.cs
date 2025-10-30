using UnityEngine;

[SelectionBase]
public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 2;

    void FixedUpdate()
    {
        HorizontalRotate();
    }

    public void PickUp() => gameObject.Off();

    private void HorizontalRotate() => transform.Rotate(0, _rotationSpeed, 0);
}
