using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField] private List<GameObject> statusClothes;
    [SerializeField] private List<int> statusEdge;
    [SerializeField] private int money = 0;
    [SerializeField] private Image filledImage;

    private UIController uIController;
    int statIndex = 0;

    private void Start()
    {
        uIController = GetComponent<UIController>();
        uIController.ShowMoney(money);
        UpdateFilledImage();
    }

    private void CheckPlayerStatus()
    {
        if (money > 0)
        {
            foreach (GameObject clothing in statusClothes)
                clothing.SetActive(false);

            for (int i = 0; i < statusEdge.Count; i++)
            {
                if (money < statusEdge[i])
                {
                    if (i < statusClothes.Count)
                    {
                        statusClothes[i].SetActive(true);
                        statIndex = i;
                    }
                    UpdateFilledImage();
                    return;
                }
            }

            if (statusClothes.Count > 0)
            {
                statusClothes[statusClothes.Count - 1].SetActive(true);
                statIndex = statusClothes.Count - 1;
            }
        }
        else 
        {
            uIController.Lose();
            GetComponent<PlayerMovement>().SetAnimation(0);
            GetComponent<PlayerMovement>().StopMove();
        }
        UpdateFilledImage();
    }

    public void SetMoney(int count)
    {
        money += count;
        money = Mathf.Max(money, 0);
        uIController.ShowMoney(money);
        CheckPlayerStatus();
    }

    public int GetStstusIndex()
    {
        return statIndex;
    }

    private void UpdateFilledImage()
    {
        if (statusEdge.Count > 0)
        {
            int maxEdge = statusEdge[statusEdge.Count - 1];
            filledImage.fillAmount = (float)money / maxEdge;
        }
    }
}
