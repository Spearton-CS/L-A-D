using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int Cash;
    public float[] SpawnCD = { 3, -1, -1, -1 };
    public float[] practicSpawnCD = { 3, -1, -1, -1 };
    private bool boss = false;
    [SerializeField]
    private Text cash;
    private int[] Light = { 1, 1, 1, 1, 1 };
    private int[] LightCost = { 8, 9, 7, 6, 10 };
    private int[] Dark = { 1, 0, 0, 0 };
    private int[] DarkCost = { 10, 20, 35, 50 };
    [SerializeField]
    private GameObject[] LightPluses = new GameObject[5];
    [SerializeField]
    private GameObject[] LightPrices = new GameObject[5];
    [SerializeField]
    private GameObject[] DarkPluses = new GameObject[4];
    [SerializeField]
    private GameObject[] DarkPrices = new GameObject[4];
    [SerializeField]
    private Text[] LightLvls = new Text[5];
    [SerializeField]
    private Text[] DarkLvls = new Text[4];
    [SerializeField]
    private GameObject Upgrades;
    [SerializeField]
    private GameObject E;
    [SerializeField]
    private PlayerLogic player;
    [SerializeField]
    private Transform[] Spawners = new Transform[8];
    private int u = 0;
    [SerializeField]
    private GameObject[] Enemies = new GameObject[5];

    private void Update()
    {
        cash.text = $"{Cash}";
        if(Input.GetKeyDown(KeyCode.E))
        {
            E.SetActive(!E.activeSelf);
            Upgrades.SetActive(!Upgrades.activeSelf);
        }
        for (int i = 0; i < 3; i++)
        {
            if (practicSpawnCD[i] > 0)
                practicSpawnCD[i] -= Time.deltaTime;
            if(practicSpawnCD[i] < 0 && practicSpawnCD[i] > -1)
            {
                Enemies[i].transform.position = Spawners[u++ % 8].position;
                Instantiate(Enemies[i]);
                practicSpawnCD[i] = SpawnCD[i];
            }
        }
        bool isf = true;
        foreach (int d in Dark)
        {
            if (d != 5) isf = false;
        }
        if (!boss && isf)
        {
            Enemies[4].transform.position = Spawners[u++ % 8].position;
            Instantiate(Enemies[4]);
            boss = true;
        }
    }


    // DARK
    public void UpgradeBasic()
    {
        if (DarkCost[0] <= Cash)
        {
            Cash -= DarkCost[0];
            DarkCost[0] *= Dark[0] + 1;
            Dark[0] += 1;
            SpawnCD[0] -= 0.5f;
            DarkPrices[0].GetComponent<Text>().text = $"Price: {LightCost[0]}";
            DarkLvls[0].text = $"{Light[0]} LVL";
        }
        if (Dark[0] == 5)
        {
            DarkPluses[0].SetActive(false);
            DarkPrices[0].SetActive(false);
        }
    }
    public void UpgradeSword()
    {
        if (DarkCost[1] <= Cash)
        {
            Cash -= DarkCost[1];
            DarkCost[1] *= Dark[1] + 1;
            Dark[1] += 1;
            if (Dark[1] == 1)
            {
                SpawnCD[1] = 3.5f;
                practicSpawnCD[1] = 3f;
            }
            SpawnCD[1] -= 0.5f;
            DarkPrices[1].GetComponent<Text>().text = $"Price: {LightCost[1]}";
            DarkLvls[1].text = $"{Light[1]} LVL";
        }
        if (Dark[1] == 5)
        {
            DarkPluses[1].SetActive(false);
            DarkPrices[1].SetActive(false);
        }
    }
    public void UpgradeArcher()
    {
        if (DarkCost[2] <= Cash)
        {
            Cash -= DarkCost[2];
            DarkCost[2] *= Dark[2] + 1;
            Dark[2] += 1;
            if (Dark[2] == 1)
            {
                SpawnCD[2] = 3.5f;
                practicSpawnCD[2] = 3f;
            }
            SpawnCD[2] -= 0.5f;
            DarkPrices[2].GetComponent<Text>().text = $"Price: {LightCost[2]}";
            DarkLvls[0].text = $"{Light[2]} LVL";
        }
        if (Dark[2] == 5)
        {
            DarkPluses[2].SetActive(false);
            DarkPrices[2].SetActive(false);
        }
    }
    public void UpgradeKnight()
    {
        if (DarkCost[3] <= Cash)
        {
            Cash -= DarkCost[3];
            DarkCost[3] *= Dark[3] + 1;
            Dark[3] += 1;
            if (Dark[3] == 1)
            {
                SpawnCD[3] = 3.5f;
                practicSpawnCD[3] = 3f;
            }
            SpawnCD[3] -= 0.5f;
            DarkPrices[3].GetComponent<Text>().text = $"Price: {LightCost[3]}";
            DarkLvls[3].text = $"{Light[3]} LVL";
        }
        if (Dark[3] == 5)
        {
            DarkPluses[3].SetActive(false);
            DarkPrices[3].SetActive(false);
        }
    }
    // LIGHT
    public void UpgradeHealth()
    {
        if (LightCost[0] <= Cash)
        {
            Cash -= LightCost[0];
            LightCost[0] *= Light[0] + 2;
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
            LightCost[1] *= Light[1] + 2;
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
            LightCost[2] *= Light[2] + 2;
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
            LightCost[3] *= Light[3] + 2;
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
            LightCost[4] *= Light[4] + 2;
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