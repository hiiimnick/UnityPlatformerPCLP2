using UnityEngine;

public class miscareJucator : MonoBehaviour
{
    [SerializeField] private float viteza;
    [SerializeField] private LayerMask layerPamant; //adaugat layer pentru a verifica daca jucatorul atinge pamantul
    [SerializeField] private LayerMask layerPerete; //adaugat layer pentru a verifica daca jucatorul atinge un perete

    private BoxCollider2D boxCollider;
    private Rigidbody2D corp;
    private Animator animatie;
    private float miscare;

    private void Awake() //de fiecare data cand pornesc jocul, se executa scriptul
    {
        corp = GetComponent<Rigidbody2D>();
        animatie = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() //se executa la fiecare frame
    {
        miscare = Input.GetAxis("Horizontal"); //daca apasam A, jucatorul face stanga, iar daca apasam D, jucatorul face dreapta
        corp.velocity = new Vector2(miscare * viteza, corp.velocity.y);
        
        
        if(miscare > 0.01f) //schimba orientarea sprite-ului bazat pe directia in care se misca jucatorul
            transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        else if(miscare < -0.01f)
            transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);

        if (Input.GetKey(KeyCode.Space) && pePamant())
            Saritura();

        animatie.SetBool("Alergare", miscare != 0); //verifica daca jucatorul se misca si schimba animatia corespunzator
        animatie.SetBool("peTeren", pePamant());
    }

    private bool pePamant()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 0.1f, layerPamant);
        return hit.collider != null; // daca jucatorul atinge pamantul, returneaza true altfel false
    }

    private void Saritura()
    {
        corp.velocity = new Vector2(corp.velocity.x, viteza);
    }
    private bool perete()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, layerPerete);
        return hit.collider != null; // daca jucatorul atinge un perete, returneaza true altfel false
    }

    public bool poateAtaca()
    {
        return miscare == 0 && pePamant();
    }

}
