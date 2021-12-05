using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/// <summary>
/// CoinsManager class to manage coins, add, substract...
/// </summary>
public class CoinManager : MonoBehaviour
{
    public static Action<object> OnCoinsCountChanged;
    [SerializeField] GameObject coinsPanel;
    [SerializeField] TextMeshProUGUI coinsLabel;
    public static int Coins { get; private set; }

    private void Awake()
    {
        GameController.OnCoinsLoaded += SetInitCoins;
        InventoryManager.OnPurchaseItemSuccess += SubstractFromCoins;
    }

    //Update coins text.
    private void UpdateCoinsText()
    {
        coinsLabel.text = Coins.ToString();
    }

    //Update coins when purchase is accrued.
    private void SubstractFromCoins(ItemButton item)
    {
        if (item != null && !item.RepresentedItem.isPurchased && item.RepresentedItem.price > 0)
        {
            Coins = Coins - item.RepresentedItem.price;
            item.RepresentedItem.isPurchased = true;
            UpdateCoinsText();

        }
    }

    //Update coins when game is loaded.
    private void SetInitCoins(int coinsCount)
    {
        Coins = coinsCount;
        UpdateCoinsText();
    }

    private void OnDisable()
    {
        InventoryManager.OnPurchaseItemSuccess -= SubstractFromCoins;
    }

}
