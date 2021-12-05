using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Matific/Section System", fileName = "Section System")]
public class SectionSystemObject : ScriptableObject
{
    
    [SerializeField] CustomObjectConfig[] customObjectsConfig;

    //Retruns only a list of the active sections.
    public List<CustomObjectConfig> GetActiveSections()
    {
        List<CustomObjectConfig> activeSectionsList = new List<CustomObjectConfig>();
        foreach(CustomObjectConfig customObject in customObjectsConfig)
        {
            if (IsSectionActive(customObject))
            {
                activeSectionsList.Add(customObject);
            }
        }
        if (activeSectionsList.Count == 0)
        {
            Debug.LogWarning("There was no active section found");
        }
        return activeSectionsList;
    }

    //Retruns only a list of the active sections by order.
    public List<CustomObjectConfig> GetActiveSectionsByOrder()
    {
        List<CustomObjectConfig> activeSectionsListByOrder = GetActiveSections();
        Utility.IntArrayQuickSort(activeSectionsListByOrder);
        return activeSectionsListByOrder;
    }

    public int GetActiveSectionsCount()
    {
        int counter = 0;
        foreach (CustomObjectConfig customObject in customObjectsConfig)
        {
            if (customObject.isActive == true) counter++;
        }
        return counter;
    }

    //Check if section is active.
    public bool IsSectionActive(CustomObjectConfig customObject)
    {
        return customObject.isActive;
    }

}

[Serializable]
public class CustomObjectConfig
{
    public CustomObject customObject; //The section it self.
    public bool isActive; //to show section in the menu or not.
    public int order; //Order of the section in the section menu.
}
