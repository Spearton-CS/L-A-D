using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int Cash;
    [SerializeField]
    private Text cash;
    private int[] Light = { 1, 1, 1, 1, 1 };
    private int[] LightCost = { 8, 9, 7, 6, 10 };
    [SerializeField]
    private GameObject[] LightPluses = new GameObject[5];
    [SerializeField]
    private GameObject[] LightPrices = new GameObject[5];
    [SerializeField]
    private Text[] LightLvls = new Text[5];
    [SerializeField]
    private GameObject Upgrades;
    [SerializeField]
    private GameObject E;
    [SerializeField]
    private PlayerLogic player;

    private void Update()
    {
        cash.text = $"{Cash}";
        if(Input.GetKeyDown(KeyCode.E))
        {
            E.SetActive(!E.activeSelf);
            Upgrades.SetActive(!Upgrades.activeSelf);
        }
    }
    public void UpgradeHealth()
    {
        if (LightCost[0] <= Cash)
        {
            Cash -= LightCost[0];
            LightCost[0] *= Light[0] + 3;
            Light[0] += 1;
            player.MaxHealth += 40;
            player.Health += 40;
            LightPrices[0].GetComponent<Text>().text = $"Price: {LightCost[0]}";
            LightLvls[0].text = $"{Light[0]} LVL";
        }
        if (Light[0] == 5)
        {
            LightPluses[0].SetActive(false);
            LightPrices[0].SetActive(false);
        }
    }
    public void UpgradeDamage()
    {
        if (LightCost[1] <= Cash)
        {
            Cash -= LightCost[1];
            LightCost[1] *= Light[1] + 3;
            Light[1] += 1;
            switch (Light[1])
            {
                case 1:
                    player.Damage = 10;
                    break;
                case 2:
                    player.Damage = 20;
                    break;
                case 3:
                    player.Damage = 40;
                    break;
                case 4:
                    player.Damage = 60;
                    break;
                case 5:
                    player.Damage = 100;
                    break;
            }
        }
        if (Light[1] == 5)
        {
            LightPluses[1].SetActive(false);
            LightPrices[1].SetActive(false);
        }
        LightPrices[1].GetComponent<Text>().text = $"Price: {LightCost[1]}";
        LightLvls[1].text = $"{Light[1]} LVL";
    }
    public void UpgradeSpeed()
    {
        if (LightCost[2] <= Cash)
        {
            Cash -= LightCost[2];
            LightCost[2] *= Light[2] + 3;
            Light[2] += 1;
            player.Speed += 2f;
        }
        if (Light[2] == 5)
        {
            LightPluses[2].SetActive(false);
            LightPrices[2].SetActive(false);
        }
        LightPrices[2].GetComponent<Text>().text = $"Price: {LightCost[2]}";
        LightLvls[2].text = $"{Light[2]} LVL";
    }
    public void UpgradeSpell()
    {
        if (LightCost[3] <= Cash)
        {
            Cash -= LightCost[3];
            LightCost[3] *= Light[3] + 3;
            Light[3] += 1;
            player.SpellSpeed += 2.25f;
        }
        if (Light[3] == 5)
        {
            LightPluses[3].SetActive(false);
            LightPrices[3].SetActive(false);
        }
        LightPrices[3].GetComponent<Text>().text = $"Price: {LightCost[3]}";
        LightLvls[3].text = $"{Light[3]} LVL";
    }
    public void UpgradeCast()
    {
        if (LightCost[4] <= Cash)
        {
            Cash -= LightCost[4];
            LightCost[4] *= Light[4] + 3;
            Light[4] += 1;
            switch (Light[4])
            {
                case 1:
                    player.SpellCD = 2f;
                    break;
                case 2:
                    player.SpellCD = 1.5f;
                    break;
                case 3:
                    player.SpellCD = 1.2f;
                    break;
                case 4:
                    player.SpellCD = 1f;
                    break;
                case 5:
                    player.SpellCD = 0.5f;
                    break;
            }
        }
        if (Light[4] == 5)
        {
            LightPluses[4].SetActive(false);
            LightPrices[4].SetActive(false);
        }
        LightPrices[4].GetComponent<Text>().text = $"Price: {LightCost[4]}";
        LightLvls[4].text = $"{Light[4]} LVL";
    }
}