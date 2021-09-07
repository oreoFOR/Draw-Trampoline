using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] LevelManager levelManager;
    bool levelComplete;
    bool levelFail;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        TinySauce.OnGameStarted(scene.buildIndex.ToString());
    }
    public void LevelClear()
    {
        if (!levelFail)
        {
            Scene scene = SceneManager.GetActiveScene();
            TinySauce.OnGameFinished(true,1,scene.buildIndex.ToString());
            levelManager.IncrementLevel();
            uiManager.LevelClear();
            levelComplete = true;
        }
    }
    public void LevelFail()
    {
        if (!levelComplete)
        {
            Scene scene = SceneManager.GetActiveScene();
            TinySauce.OnGameFinished(false, 0, scene.buildIndex.ToString());
            uiManager.LevelFail();
            levelFail = true;
        }
    }
}
