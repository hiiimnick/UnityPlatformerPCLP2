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

        durataViata += Time.deltaTime;
        if (durataViata > 3)
            Distrugere();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lovit = true;
        boxCollider.enabled = false;
        animatie.SetTrigger("explozie");

        if(collision.tag == "Inamic")
        {
            collision.GetComponent<Viata>().IaDaune(1);
        }
    }

    public void Directie(float mdirectie)
    {
        durataViata = 0;
        directie = mdirectie;
        gameObject.SetActive(true);
        lovit = false;
        boxCollider.enabled = true;

        float auxlocalScaleX = transform.localScale.x;

        if (Mathf.Sign(auxlocalScaleX) != mdirectie)
            auxlocalScaleX = -auxlocalScaleX;

        transform.localScale = new Vector3(auxlocalScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Distrugere()
    {
        gameObject.SetActive(false);
    }
}
