using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTrailScript : MonoBehaviour
{
    // as long as the player is touching the ground, the walking trail renderer will follow, nonetheless it won't
    private PlayerMovement player;
    private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.TrailEmitting())
        {
            tr.emitting = false;
        }
        else
        {
            tr.emitting = true;
        }
        
    }
}
