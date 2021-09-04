using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject successCanvas;
    [SerializeField] GameObject failCanvas;
    [SerializeField] GameObject baseConfettis;
    [SerializeField] GameObject winSpecificConfettis;
    public void LevelClear()
    {
        baseConfettis.SetActive(true);
        successCanvas.SetActive(true);
        winSpecificConfettis.SetActive(true);
    }
    public void LevelFail()
    {
        baseConfettis.SetActive(true);
        failCanvas.SetActive(true);
    }
}
