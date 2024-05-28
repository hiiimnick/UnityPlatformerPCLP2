using UnityEngine;

public class Patrulare : MonoBehaviour
{
    [Header("Patrula")]
    [SerializeField] private Transform margineStanga;
    [SerializeField] private Transform margineDreapta;


    [Header("Inamic")]
    [SerializeField] private Transform inamic;

    [Header("Miscare")]
    [SerializeField] private float viteza;
    private bool miscareStanga;

    private void Update()
    {
        if(miscareStanga)
        {
            if(inamic.position.x > margineStanga.position.x)
            {
                directie(-1);
            }
            else
            {
                schimbaDirectie();
            }
        }
        else
        {
            if(inamic.position.x < margineDreapta.position.x)
            {
                directie(1);
            }
            else
            {
                schimbaDirectie();
            }
        }
    }

    private void schimbaDirectie()
    {
        miscareStanga = !miscareStanga;

    }

    private void directie(int mdirectie)
    {
        inamic.position = new Vector3(inamic.position.x + mdirectie * Time.deltaTime * viteza, inamic.position.y, inamic.position.z);
    }
}
