using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public static Buy Instance { get; private set; }
    
    private Text playerMoneyText;
    private Text populationText;
    public GameObject shop;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerMoneyText = GameObject.Find("PlayerMoneyText").GetComponent<Text>();
        populationText = GameObject.Find("PopNum").GetComponent<Text>();
    }

    public void _Buy(BuildingSO building)
    {
        int price = building.price;
        int playerMoney = int.Parse(playerMoneyText.text);
        if (playerMoney >= price)
        {
            playerMoney -= price;
            playerMoneyText.text = playerMoney.ToString();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    
    public void AddPeople(BuildingSO building)
    {
        int peopleToAdd = building.peopleToAdd;
        int totalPeople = int.Parse(populationText.text);
        totalPeople += peopleToAdd;
        populationText.text = totalPeople.ToString();
    }
    
    public void CloseShop()
    {
        shop.SetActive(false);
    }
}
