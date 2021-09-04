using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] float ballsToFill;
    [SerializeField]int ballsEntered;
    [SerializeField] GameManager gm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.layer = 4;
            if (ballsEntered < ballsToFill)
            {
                ballsEntered += 1;
            }
            else
            {
                CupFilled();
            }
        }
    }
    void CupFilled()
    {
        gm.LevelClear();
    }
}
