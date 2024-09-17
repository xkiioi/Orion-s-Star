using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int starsCollected;

    // Collision - Touches the edge of a collider (walls)
    // Triggers - Goes through a collider (projectiles)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            starsCollected++;
            Destroy(collision.gameObject);
        }
    }

}
