using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private bool destructable = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<StatusController>().SetMoney(money);
            if(destructable) Destroy(gameObject);
        }
    }
}
