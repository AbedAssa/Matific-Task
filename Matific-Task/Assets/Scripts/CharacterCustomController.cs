using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomController : MonoBehaviour
{
    [SerializeField] SpriteRenderer _outfit;
    [SerializeField] SpriteRenderer _eyes;
    [SerializeField] SpriteRenderer _mouth;

    private void Start()
    {
        _outfit.gameObject.SetActive(false);
        _eyes.gameObject.SetActive(false);
        _mouth.gameObject.SetActive(false);
       InventoryManager.OnPurchaseItemSuccess += UpdateCharacter;

    }

    private void UpdateCharacter(ItemButton buttonItem)
    {
        switch (buttonItem.Section)
        {
            case ESection.Eyes:
                UpdateEyes(buttonItem.RepresentedItem);
                break;
            case ESection.Outfits:
                UpdateOutfit(buttonItem.RepresentedItem);
                break;
            case ESection.Mouths:
                UpdateMouth(buttonItem.RepresentedItem);
                break;
        }
    }

    private void UpdateEyes(Item item)
    {
        _eyes.gameObject.SetActive(true);
        _eyes.sprite = item.itemCustom;
    }

    private void UpdateOutfit(Item item)
    {
        _outfit.gameObject.SetActive(true);
        _outfit.sprite = item.itemCustom;

    }

    private void UpdateMouth(Item item)
    {
        _mouth.gameObject.SetActive(true);
        _mouth.sprite = item.itemCustom;
    }
}
