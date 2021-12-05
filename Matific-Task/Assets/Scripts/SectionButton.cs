using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using TMPro;

public class SectionButton : Button, IPointerClickHandler
{
    public static Action<ESection> OnSectionButtonClicked;

    public ESection section;

    public void ChangeButtonText(string buttonText)
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonText;
    }

    public override void OnPointerClick(PointerEventData pointerEventData)
    {
        OnSectionButtonClicked?.Invoke(section);
    }
}



