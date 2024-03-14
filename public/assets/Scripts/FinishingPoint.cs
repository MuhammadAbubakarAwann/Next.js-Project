using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingPoint : MonoBehaviour
{
    private bool somethingCollided;

    // Start is called before the first frame update
    void Start()
    {
        somethingCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        somethingCollided = true;
    }

    public bool CollisionOccured()
    {
        return somethingCollided;
    }
}
