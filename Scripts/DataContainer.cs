using UnityEngine;

public class DataContainer : MonoBehaviour
{
    [SerializeField] private int money;

    public void SetMoney(int value)
    {
        money += value;
    }
}
