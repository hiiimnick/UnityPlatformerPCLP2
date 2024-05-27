using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Viata : MonoBehaviour
{
    //o sa fac viata modulara, in caz ca o sa refolosesc codul candva
    [SerializeField] public float viataMaxima;
    public float viataCurenta;

    private void Awake()
    {
        viataCurenta = viataMaxima;
    }

    public void IaDaune(float daune)
    {
        viataCurenta = Mathf.Clamp(viataCurenta - daune, 0, viataMaxima);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            IaDaune(1);
    }
}
