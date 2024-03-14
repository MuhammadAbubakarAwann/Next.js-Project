using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustCloudBehaviour : MonoBehaviour
{
    public float particleDestroyTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, particleDestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
