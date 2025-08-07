using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAtYLevel : MonoBehaviour
{
    // The Y level where the object destroys itself
    public float yLevel;
    // If false, despawns when Y level is below, if true, despawns if above
    public bool despawnAbove;
    
    
    private void Update()
    {
        if ((despawnAbove && transform.position.y > yLevel) || (!despawnAbove && transform.position.y < yLevel))
        {
            Destroy(gameObject);
        } 
    }
}
