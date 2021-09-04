using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Material[] mats;
    [SerializeField] MeshRenderer rends;
    private void Start()
    {
        int i = Random.Range(0, mats.Length);
        rends.material = mats[i];
    }
}
