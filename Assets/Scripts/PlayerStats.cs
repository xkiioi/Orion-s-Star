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
        if (collision.CompareTag("Collectable"))
        {
            starsCollected++;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (starsCollected == 1)
        {
            starText.text = starsCollected + " star".ToString();
        }
        else
            starText.text = starsCollected + " stars".ToString();
    }

}
