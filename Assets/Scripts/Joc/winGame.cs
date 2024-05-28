using UnityEngine;

public class winGame : MonoBehaviour
{
    private UIManager UIManager;

    private void Awake()
    {
        UIManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.AfiseazaEcranWin();
            Time.timeScale = 0;
        }
    }
}
