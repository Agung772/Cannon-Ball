using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCannonBall : MonoBehaviour
{
    public float timeDestroy;

    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
}
