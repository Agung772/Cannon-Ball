using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public bool hasFallen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FallenWallDetector>())
        {
            hasFallen = true;

            GameManager.instance.BrickFall();
        }
    }
}
