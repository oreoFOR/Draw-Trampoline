using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] LevelManager levelManager;
    bool levelComplete;
    bool levelFail;
    public void LevelClear()
    {
        if (!levelFail)
        {
            levelManager.IncrementLevel();
            uiManager.LevelClear();
            levelComplete = true;
        }
    }
    public void LevelFail()
    {
        if (!levelComplete)
        {
            uiManager.LevelFail();
            levelFail = true;
        }
    }
}
