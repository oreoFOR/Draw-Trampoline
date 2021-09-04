using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    [SerializeField]int failedBalls;
    [SerializeField] int failureAmount;
    [SerializeField] GameManager gm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && failedBalls < failureAmount)
        {
            failedBalls += 1;
            if (failedBalls == failureAmount)
            {
                gm.LevelFail();
            }
        }
    }
}
