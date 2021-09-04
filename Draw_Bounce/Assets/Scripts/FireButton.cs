using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{
    [SerializeField] CircleCollider2D col;
    [SerializeField] BallShooter shooter;
    public bool CheckButton()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (col.OverlapPoint(mousePosition))
        {
            shooter.shooting = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
