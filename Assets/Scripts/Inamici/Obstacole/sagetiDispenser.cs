using UnityEngine;

public class sagetiDispenser : dauneInamici
{
    [SerializeField] private float viteza;
    [SerializeField] private float timpResetare;
    private float durataViata;

    public void activareProiectil()
    {
        durataViata = 0;
        gameObject.SetActive(true);

    }

    private void Update()
    {
        float vitezaSagetii = viteza * Time.deltaTime;
        transform.Translate(vitezaSagetii, 0, 0);

        durataViata += Time.deltaTime;
        if (durataViata > timpResetare)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); //apeleaza mai intai ontrigger-ul din dauneInamici
        gameObject.SetActive(false);
    }
}
