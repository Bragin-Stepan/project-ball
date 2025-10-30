using UnityEngine;

[SelectionBase]
public class Coin : MonoBehaviour
{
    void FixedUpdate()
    {
        HorizontalRotate();
    }

    public void PickUp() => gameObject.Off();

    private void HorizontalRotate() => transform.Rotate(0, 1, 0);
}
