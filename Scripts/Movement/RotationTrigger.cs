using UnityEngine;

public class RotationTrigger : MonoBehaviour
{
    [SerializeField] private float rotateAngle = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerMovement>().RotatePlayer(rotateAngle);
    }
}
