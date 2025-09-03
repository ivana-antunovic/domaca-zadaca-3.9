using UnityEngine;
using UnityEngine.UI;

public class AddListener : MonoBehaviour
{
    [SerializeField] private Button scoreButton;
    [SerializeField] private Button healthButton;

    private void Awake()
    {
        scoreButton = GameObject.Find("AddScore").GetComponent<Button>();
        healthButton = GameObject.Find("ChangeHealth").GetComponent<Button>();
    }
    private void Start()
    {
        scoreButton.onClick.AddListener(() => { UIManager.instance.AddScore(); });

        healthButton.onClick.AddListener(() => { UIManager.instance.ChangeHealth(); });

        // tu sam dodala da se moze dodijeliti on click funkcija bez da se u inspectoru namjesta
    }
}
