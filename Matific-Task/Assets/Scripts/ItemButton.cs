using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ItemButton : MonoBehaviour
{
    public static Action<ItemButton> OnItemButtonClicked;
    public Item RepresentedItem { get; private set; }
    public ESection Section { get; private set; }
    [SerializeField] GameObject _levelPanelParent;
    [SerializeField] TextMeshProUGUI _minLevelText;
    [SerializeField] GameObject _pricePanelParent;
    [SerializeField] TextMeshProUGUI _priceText;
    [SerializeField] Image _itemIcon;

    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnItemClicked);
    }

    public void ChangeIcon(Sprite sprite)
    {
        _itemIcon.sprite = sprite;
    }

    public void ShowLevelLabel(int level)
    {
        _levelPanelParent.SetActive(true);
        _minLevelText.text = "Level " + level;
    }

    public void HideLevelLabel()
    {
        _levelPanelParent.SetActive(false);
    }

    public void ShowPriceLabel(int price)
    {
        _pricePanelParent.SetActive(true);
        _priceText.text = price.ToString();
    }

    public void HidePriceLabel()
    {
        _pricePanelParent.SetActive(false);
    }

    //Get called when item button clicked
    private void OnItemClicked()
    {
        OnItemButtonClicked?.Invoke(this);
    }

    //Set item data
    public void SetItem(Item item)
    {
        RepresentedItem = item;
    }

    public void SetSection(ESection section)
    {
        Section = section;
    }
}
