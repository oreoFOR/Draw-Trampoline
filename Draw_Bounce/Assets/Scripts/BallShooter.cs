using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    [SerializeField] float delay;
    int ammo;
    [SerializeField] GameObject[] balls;
    [SerializeField] float ballForce;
    [SerializeField] Transform shootPoint;
    [SerializeField] int ballLayer;
    int shotsFired;
    public bool shooting;
    private void Start()
    {
        ammo = balls.Length;
        ShootBall();
        StartCoroutine(ShootLogic());
    }
    IEnumerator ShootLogic()
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        if(shotsFired < ammo)
        {
            yield return wait;
            ShootBall();
            StartCoroutine(ShootLogic());
        }
    }
    void ShootBall()
    {
        if (shooting)
        {
            GameObject _ball = balls[shotsFired];
            _ball.transform.position = shootPoint.position;
            Rigidbody2D rb = _ball.GetComponent<Rigidbody2D>();
            _ball.layer = ballLayer;
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.right * ballForce, ForceMode2D.Impulse);
            shotsFired += 1;
        }
    }
}
