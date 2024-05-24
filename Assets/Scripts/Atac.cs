using UnityEngine;

public class Atac : MonoBehaviour
{
    //foloseste object pool ca altfel moare jocu'
    [SerializeField] private float vitezaAtac;
    [SerializeField] private GameObject[] bileFoc;
    [SerializeField] private Transform incepeBila;
    private Animator animatie;
    private miscareJucator miscare;
    private float timpAtac = 9999;

    private void Awake()
    {
        animatie = GetComponent<Animator>();
        miscare = GetComponent<miscareJucator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && vitezaAtac < timpAtac && miscare.poateAtaca())
            Atacare();

        timpAtac += Time.deltaTime;
    }

    private void Atacare()
    {
        animatie.SetTrigger("Atac");
        timpAtac = 0;

        bileFoc[gasesteBila()].transform.position = incepeBila.position;
        bileFoc[gasesteBila()].GetComponent<bilaFoc>().Directie(Mathf.Sign(transform.localScale.x));
    }

    private int gasesteBila()
    {
        for (int i = 0; i < bileFoc.Length; i++)
            if (!bileFoc[i].activeInHierarchy)
                return i;
        return 0;
    }
}
