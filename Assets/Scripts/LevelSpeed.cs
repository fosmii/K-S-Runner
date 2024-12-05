using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeed : MonoBehaviour
{
    float speed = 1f; // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        speed *= 1.1f;
    }
}
