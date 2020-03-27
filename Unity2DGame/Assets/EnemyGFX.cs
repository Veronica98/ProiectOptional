using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f) //velocity that the enemy would like to travel in the current path
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f) //in this case we are moving to the left
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); //we flip the bird
        }
    }
}
