using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Player player;
    private int playerHealth;

    [SerializeField] private Image[] hearts;

    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        playerHealth = player.health;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = (i < playerHealth) ? Color.red : Color.black;
        }
    }
}
