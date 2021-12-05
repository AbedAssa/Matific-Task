using UnityEngine;

/// <summary>
/// Base class for customization the character.
/// To add more customization derive from this class.
/// </summary>
public abstract class CustomObject : ScriptableObject
{
    public ESection section;
    public Item[] sectionItems;         
}
