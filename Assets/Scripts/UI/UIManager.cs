using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject ecranGameOver;
    [SerializeField] private GameObject ecranWin;

    public void AfiseazaEcranGameOver()
    {
        ecranGameOver.SetActive(true);
        if (Input.GetKey(KeyCode.Return)) // de ce nu mai merge
        {
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    public void AfiseazaEcranWin()
    {
        ecranWin.SetActive(true);
        if (Input.GetKey(KeyCode.Return)) // de ce nu mai merge
        {
            Application.Quit();

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
