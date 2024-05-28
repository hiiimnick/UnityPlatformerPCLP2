using UnityEngine;

public class dauneInamici : MonoBehaviour
{
    [SerializeField] protected float daune;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Viata>().IaDaune(daune);
        }
    }
}
