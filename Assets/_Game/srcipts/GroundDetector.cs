using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Ground>())
            IsGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ground>())
            IsGrounded = false;
    }
}
