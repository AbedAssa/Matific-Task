using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public static Action<int> OnCoinsLoaded;
    public static Action<int> OnLevelLoaded;

    private void Awake()
    {
        UserData userData = UserDataGetter.GetUserData();
        OnCoinsLoaded?.Invoke(userData.Coins);
        OnLevelLoaded?.Invoke(userData.Level);
    }
}
