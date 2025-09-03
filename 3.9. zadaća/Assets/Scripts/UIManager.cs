using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score;


    [SerializeField] private Image healthImage;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;


    public event UnityAction increaseScore;
    public event UnityAction decreaseHealth;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateText();
        UpdateHealth();
    }

    private void UpdateText()
    {
      
       scoreText.text = $"Score: {score}";
    }

    private void UpdateHealth()
    {
        if(healthImage != null)
        {
            healthImage.fillAmount = currentHealth / maxHealth;  
        }
    }

    public void ChangeHealth(float amount = 1f)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealth();
        decreaseHealth?.Invoke();
    }

    public void AddScore(int amount = 5)
    {
        score += amount;
        UpdateText();
        increaseScore?.Invoke();
    }

    //imam neki filing da sam nesto mogla bolje napraviti ali nemam pojma sta
}
