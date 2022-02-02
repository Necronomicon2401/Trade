using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int playerGold = 100;
    public int traderGold = 200;
    [SerializeField] public List<GameObject> playerItems;
    [SerializeField] public List<GameObject> traderItems;
    
    private TextMeshProUGUI playerGoldText;
    private TextMeshProUGUI traderGoldText;
    
    // Start is called before the first frame update
    void Start()
    {
        var texts = FindObjectsOfType<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            if (text.name.Equals("PlayerGold"))
            {
                playerGoldText = text;
            }

            if (text.name.Equals("TraderGold"))
            {
                traderGoldText = text;
            }
        }

        UpdateGold();
    }

    public void UpdateGold()
    {
        playerGoldText.text = playerGold.ToString();
        traderGoldText.text = traderGold.ToString();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
