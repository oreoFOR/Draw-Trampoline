using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{
    [SerializeField] float upForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * upForce);
        }
    }
}
