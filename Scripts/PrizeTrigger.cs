using UnityEngine;

public class PrizeTrigger : MonoBehaviour
{
    [SerializeField] private int gateIndex = 1;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject;
            int i = player.GetComponent<StatusController>().GetStstusIndex();
            if (i == gateIndex - 1)
            {
                player.GetComponent<PlayerMovement>().StopMove();
                player.GetComponent<PlayerMovement>().SetAnimation(1);
                player.GetComponent<UIController>().Win(gateIndex);
            }
            else animator.SetBool("Open", true);
        }
    }
}
