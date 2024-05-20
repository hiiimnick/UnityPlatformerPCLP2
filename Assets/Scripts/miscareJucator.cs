using UnityEngine;

public class miscareJucator : MonoBehaviour
{
    [SerializeField] private float viteza;
    private Rigidbody2D corp;
    private Animator animatie;
    private bool peTeren;

    private void Awake() //de fiecare data cand pornesc jocul, se executa scriptul
    {
        corp = GetComponent<Rigidbody2D>();
        animatie = GetComponent<Animator>();
    }

    private void Update() //se executa la fiecare frame
    {
        float miscare = Input.GetAxis("Horizontal"); //daca apasam A, jucatorul face stanga, iar daca apasam D, jucatorul face dreapta
        corp.velocity = new Vector2(miscare * viteza, corp.velocity.y);
        
        
        if(miscare > 0.01f) //schimba orientarea sprite-ului bazat pe directia in care se misca jucatorul
            transform.localScale = Vector3.one;
        else if(miscare < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && peTeren)
            Saritura();

        animatie.SetBool("Alergare", miscare != 0); //verifica daca jucatorul se misca si schimba animatia corespunzator
        animatie.SetBool("peTeren", peTeren);
    }
    private void Saritura()
    {
        corp.velocity = new Vector2(corp.velocity.x, viteza);
        peTeren = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Teren")
        {
            peTeren = true;
        }
    }
}
