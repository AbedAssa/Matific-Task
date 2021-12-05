using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// InventoryManager instantiate an inventory in denamic way.
/// </summary>
public class InventoryManager : MonoBehaviour
{
    public static Action<ItemButton> OnPurchaseItemSuccess;
    [SerializeField] SectionSystemObject sections;    
    [Header("Section Buttons")]
    [SerializeField] GameObject sectionButtonsParentPanel;
    [SerializeField] GameObject sectionButtonPrefab;
    [Header("Section Items")]
    [SerializeField] GameObject sectionItemParentPanel;
    [SerializeField] GameObject sectionItemPanelPrefab;
    [SerializeField] GameObject itemButtonPrefab;

    private Dictionary<ESection, GameObject> _sectionDictionary;

    private void Awake()
    {
        SectionButton.OnSectionButtonClicked += ShowClickedSection;
        ItemButton.OnItemButtonClicked += UserWantToPurchase;
    }

    private void Start()
    {
        _sectionDictionary = new Dictionary<ESection, GameObject>();
        InstantiateSection();
    }

    /// Loop throw all the section and instantiate a button for each section.
    public void InstantiateSection()
    {
        List<CustomObjectConfig> customObjectConfig = sections.GetActiveSectionsByOrder();
        for (int i=0;i<sections.GetActiveSectionsCount();i++)
        {
            GameObject createdButton = Instantiate(sectionButtonPrefab, sectionButtonsParentPanel.transform);
            SectionButton sectionButton = createdButton.GetComponent<SectionButton>();
            sectionButton.ChangeButtonText(customObjectConfig[i].customObject.section.ToString());
            sectionButton.section = customObjectConfig[i].customObject.section;
            GameObject sectionItemPanel = Instantiate(sectionItemPanelPrefab, sectionItemParentPanel.transform);
            ActivateFirstSectionInOrder(sectionItemPanel, i == 0);
            InstantiateItemButtons(customObjectConfig[i], sectionItemPanel);
        }
    }

    /// Add items to sections
    public void InstantiateItemButtons(CustomObjectConfig sectionData,GameObject sectionItemPanel)
    {
        foreach (Item item in sectionData.customObject.sectionItems)
        {
            GameObject createdItemObj = Instantiate(itemButtonPrefab, sectionItemPanel.transform);
            ItemButton createdItemButton = createdItemObj.GetComponent<ItemButton>();
            createdItemButton.SetItem(item);
            createdItemButton.SetSection(sectionData.customObject.section);
            createdItemButton.ChangeIcon(item.itemCustomIcon);
            createdItemButton.RepresentedItem.isPurchased = false;
            if (IsItemOpen(item))
            {
                createdItemButton.HideLevelLabel();
                if (IsHasPrice(item))
                {
                    createdItemButton.ShowPriceLabel(item.price);
                }
                else
                {
                    createdItemButton.HidePriceLabel();
                }
            }
            else
            {
                createdItemButton.ShowLevelLabel(item.minLevel);
                createdItemButton.HidePriceLabel();
            }
        }
        _sectionDictionary.Add(sectionData.customObject.section, sectionItemPanel);
    }

    private bool IsItemOpen(Item item)
    {
        return LevelManager.Level >= item.minLevel;
    }

    private bool IsHasPrice(Item item)
    {
        return item.price > 0;
    }

    //The active section should be in index 0 always.
    private void ActivateFirstSectionInOrder(GameObject sectionPanel,bool flag)
    {
        sectionPanel.SetActive(flag);
    }

    /// Get triggered when one of the section buttons is clicked, show relative section and hide all others.
    private void ShowClickedSection(ESection clickedSection)
    {
        foreach(var k in _sectionDictionary.Keys)
        {
            _sectionDictionary[k].SetActive(false);
        }
        _sectionDictionary[clickedSection].SetActive(true);
    }

    private void UserWantToPurchase(ItemButton itemButton)
    {

        if((IsFreeItem(itemButton.RepresentedItem) && IsItemOpen(itemButton.RepresentedItem)) ||
            ( IsItemOpen(itemButton.RepresentedItem) && CanPurchase(itemButton.RepresentedItem) && !IsPurchased(itemButton.RepresentedItem))||
            IsPurchased(itemButton.RepresentedItem)
            )
                
        {
            itemButton.HidePriceLabel();
            OnPurchaseItemSuccess?.Invoke(itemButton);
        }
    }

    private bool IsFreeItem(Item item)
    {
        return item.price == 0;
    }

    private bool CanPurchase(Item item)
    {
        return item.price <= CoinManager.Coins;
    }

    private bool IsPurchased(Item item)
    {
        return item.isPurchased;
    }

    private void OnDisable()
    {
        SectionButton.OnSectionButtonClicked -= ShowClickedSection;
        ItemButton.OnItemButtonClicked -= UserWantToPurchase;

    }


}
