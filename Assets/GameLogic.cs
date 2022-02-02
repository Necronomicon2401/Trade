using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private int playerGold = 0;
    [SerializeField] private int traderGold = 0;
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
        
        foreach (var playerItem in playerItems)
        {
            playerGold += Int32.Parse(playerItem.GetComponentInChildren<TextMeshProUGUI>().text);
        }
        
        foreach (var traderItem in traderItems)
        {
            traderGold += Int32.Parse(traderItem.GetComponentInChildren<TextMeshProUGUI>().text);
        }

        playerGoldText.text = playerGold.ToString();
        traderGoldText.text = traderGold.ToString();
        playerGold = 0;
        traderGold = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
