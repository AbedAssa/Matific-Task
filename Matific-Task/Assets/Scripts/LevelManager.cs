using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelLabel;
    public static int Level { get; private set; }
    private void Awake()
    {
        GameController.OnLevelLoaded += UpdateLevel;
    }

    // Update level when game first loaded.
    void UpdateLevel(int level)
    {
        levelLabel.text = "Level: " + level;
        Level = level;
    }
}
