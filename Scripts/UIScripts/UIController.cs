using ButchersGames;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TMPro.TextMeshProUGUI moneyText;
    [SerializeField] private TMPro.TextMeshProUGUI moneyTempText;

    GameObject dataContainer;
    private void Start()
    {
        dataContainer = FindObjectOfType<DataContainer>().gameObject;
    }

    public void Lose()
    {
        losePanel.SetActive(true);
    }

    public void Win(int multipler)
    {
        dataContainer.GetComponent<DataContainer>().SetMoney(int.Parse(moneyText.text) * (multipler + 1));
        winPanel.SetActive(true);
    }

    public void ShowMoney(int money) 
    {
        moneyText.text = "" + money;
    }
    public void ShowMoney(int money, int tempmoney)
    {
        moneyText.text = "" + money;
        moneyTempText.text = "" + tempmoney;
    }

    public void RestartLevel() => dataContainer.GetComponent<LevelManager>().RestartLevel();
    public void NextLevel() => dataContainer.GetComponent<LevelManager>().NextLevel();
}
