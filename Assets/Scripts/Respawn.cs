using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold = -50f;
    public Vector3 spawnPoint;
    public ColorManager colorManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold) {
            colorManager.Reset();
            transform.position = spawnPoint;
        }
    }
}
