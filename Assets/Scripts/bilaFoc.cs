using UnityEngine;

public class bilaFoc : MonoBehaviour
{
    [SerializeField] private float viteza;
    private float durataViata;
    private bool lovit;
    private float directie;

    private Animator animatie;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animatie = GetComponent<Animator>();
    }

    private void Update()
    {
        if (lovit) 
            return;

        float vitezaMiscare = viteza * directie * Time.deltaTime;
        transform.Translate(vitezaMiscare, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lovit = true;
        boxCollider.enabled = false;
        animatie.SetTrigger("Explozie");
    }

    public void Directie(float mdirectie)
    {
        durataViata = 0;
        directie = mdirectie;
        if (Mathf.Sign(directie) == 1)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
        gameObject.SetActive(true);
        lovit = false;
        boxCollider.enabled = true;
    }

    private void Distrugere()
    {
        gameObject.SetActive(false);
    }
}
