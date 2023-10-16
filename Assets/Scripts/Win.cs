using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Win : MonoBehaviour
{
    private float startTime;
    public TextMeshProUGUI victoryText;
    public Button restartButton;

    void Start()
    {
        startTime = Time.time;
        victoryText.text = "";
        restartButton.interactable = false;
        SetButtonVisibility(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float elapsedTime = Time.time - startTime;
            victoryText.text = "������!\n����� �����������: " + elapsedTime.ToString("F2") + " ������";
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            SetButtonVisibility(true);
            restartButton.interactable = true;

            Time.timeScale = 0f;
        }
    }

    private void SetButtonVisibility(bool visible)
    {
        restartButton.gameObject.SetActive(visible);
    }
}
