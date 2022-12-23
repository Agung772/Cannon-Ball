using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfBrickSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.fallenBrickNeeded += transform.childCount;

        GameManager.instance.SetAmmo();
    }

}
