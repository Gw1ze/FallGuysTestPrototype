using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int playerHealth;
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    void Start()
    {
        playerHealth = 100;
        gameOver = false;
        gameOverText.text = "";
    }

    void FixedUpdate()
    {
        playerHealthText.text = "" + playerHealth;
        if (gameOver)
        {
            ShowGameOverScreen();
            Time.timeScale = 0f;
        }
    }

    public static void Damage (int damageCount)
    {
        playerHealth -= damageCount;
         if(playerHealth <= 0)
        {
            gameOver = true;
        }
    }

    void ShowGameOverScreen()
    {
        gameOverText.text = "Вы проиграли!";

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        SetButtonVisibility(true);
        restartButton.interactable = true;
    }

    private void SetButtonVisibility(bool visible)
    {
        restartButton.gameObject.SetActive(visible);
    }
}
