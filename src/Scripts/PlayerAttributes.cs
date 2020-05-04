using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth;
    public float maxHealth;
    public float maxLives;
    public float lives;
    public Image healthBar;
    public Image livesBar;
    public PlayerMovement player;
    public InfectedMenu lost;
    public MoveSoundsMaker MSM;

    void Awake()
    {
        healthBar.fillAmount = playerHealth / maxHealth;
        livesBar.fillAmount = lives / maxLives;
    }

    public void addHealth(float amount)
    {
        MSM.collection();
        playerHealth += amount;
        if(playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        healthBar.fillAmount = playerHealth / maxHealth;
    }

    public void subtractHealth(float amount)
    {
        MSM.getHurt();
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            loseALife();
        }

        healthBar.fillAmount = playerHealth / maxHealth;
    }

    public void loseALife()
    {
        lives -= 1;
        if (lives < 1)
        {
            lost.pauseControl();
            lost.showPaused();
            lives = 0;
        }

        livesBar.fillAmount = lives / maxLives;
        addHealth(maxHealth);
        player.resetPosition();
    }

    public void addALife()
    {
        MSM.collection();
        lives += 1;
        if (lives > maxLives)
        {
            lives = maxLives;
        }

        livesBar.fillAmount = lives / maxLives;
    }
	
	
}
