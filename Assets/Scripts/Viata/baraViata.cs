using UnityEngine;
using UnityEngine.UI;

public class baraViata : MonoBehaviour
{
    [SerializeField] private Viata viataJucator;
    [SerializeField] private Image totalBaraViata;
    [SerializeField] private Image baraViataCurenta;

    private void Start()
    {
        totalBaraViata.fillAmount = 1;
    }

    private void Update()
    {
        baraViataCurenta.fillAmount = (float)viataJucator.viataCurenta / viataJucator.viataMaxima;
    }
}
