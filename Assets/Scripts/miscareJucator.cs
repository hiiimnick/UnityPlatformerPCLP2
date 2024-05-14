using UnityEngine;

public class miscareJucator : MonoBehaviour
{
    [SerializeField] private float viteza;
    private Rigidbody2D corp;

    private void Awake() //de fiecare data cand pornesc jocul, se executa scriptul
    {
        corp = GetComponent<Rigidbody2D>();
    }

    private void Update() //se executa la fiecare frame
    {
        float miscare = Input.GetAxis("Horizontal"); //daca apasam A, jucatorul face stanga, iar daca apasam D, jucatorul face dreapta
        corp.velocity = new Vector2(miscare * viteza, corp.velocity.y);
        if(Input.GetKey(KeyCode.Space))
        {
            corp.velocity = new Vector2(corp.velocity.x, viteza);
        }
    }
}
