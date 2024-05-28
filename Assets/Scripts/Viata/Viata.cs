using UnityEngine;

public class Viata : MonoBehaviour
{
    //o sa fac viata modulara, in caz ca o sa refolosesc codul candva
    [SerializeField] public float viataMaxima;
    public float viataCurenta;
    private bool mort;
    private UIManager UIManager;

    private void Awake()
    {
        viataCurenta = viataMaxima;
        UIManager = FindObjectOfType<UIManager>();
    }

    public void IaDaune(float daune)
    {
        viataCurenta = Mathf.Clamp(viataCurenta - daune, 0, viataMaxima);
        if(viataCurenta <= 0 && !mort)
        {
            //womp womp player
            gameObject.SetActive(false);
            mort = true;
            UIManager.AfiseazaEcranGameOver();
            return;
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
            //IaDaune(1);
    }
}
