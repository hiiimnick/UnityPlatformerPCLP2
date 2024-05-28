using UnityEngine;

public class Inamic : dauneInamici
{
    [SerializeField] private float viteza;
    [SerializeField] private float distanta;

    private bool miscaDreapta;
    private float margineDreapta;
    private float margineStanga;

    private void Awake()
    {
        margineStanga = transform.position.x - distanta;
        margineDreapta = transform.position.x + distanta;
    }

    private void Update()
    {
        if(miscaDreapta)
        {
            if(transform.position.x < margineDreapta)
                transform.position = new Vector2(transform.position.x + viteza * Time.deltaTime, transform.position.y);
            else
                miscaDreapta = false;
        }
        else
        {
            if(transform.position.x > margineStanga)
                transform.position = new Vector2(transform.position.x - viteza * Time.deltaTime, transform.position.y);
            else
                miscaDreapta = true;
        }
    }
}
