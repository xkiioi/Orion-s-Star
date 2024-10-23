using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int starsCollected;
    public Text starText;

    // Collision - Touches the edge of a collider (walls)
    // Triggers - Goes through a collider (projectiles)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // tagged as collectable (something that the player can pick up)
        if (collision.CompareTag("Collectable"))
        {
            // adds a point (+1) for how many stars are collected)
            starsCollected++;
            // when collected, star game object is destroyed
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        // if the stars amount to 1 (one), the string will say "star"
        if (starsCollected == 1)
        {
            starText.text = starsCollected + " star".ToString();
        }
        //otherwise, 0 or more than 1 will have the text shown as plural.
        else
            starText.text = starsCollected + " stars".ToString();
    }

}
