using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheckPointControllerForDustParticle : MonoBehaviour
{
    // as the script for dust particle is already made so just instantiate on trigger and it will be destroyed by itsn own script
    [SerializeField]
    private GameObject dustParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // on trigger enter2D dust particle will be instantiated
    private void OnTriggerEnter2D(Collider2D other)
    {
        // add a tag for surface levels or grounds

        if (other.gameObject.tag.Equals("surface"))
        {
            Instantiate(dustParticle, transform.position, dustParticle.transform.rotation);
        }
    }
}
