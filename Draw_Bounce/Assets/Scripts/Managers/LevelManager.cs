using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void IncrementLevel()
    {
        int num = PlayerPrefs.GetInt("LevelNum");
        num += 1;
        PlayerPrefs.SetInt("LevelNum", num);
    }
    [Button]
    void ResetLevelNum()
    {
        PlayerPrefs.SetInt("LevelNum", 0);
    }
}
