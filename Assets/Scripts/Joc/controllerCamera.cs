using UnityEngine;

public class controllerCamera : MonoBehaviour
{
    //o sa fie camera de tip follow player


    [SerializeField] private Transform jucator;
    [SerializeField] private float vitezaCamera;
    private float uiteInFata;
    [SerializeField] private float distInFata;

    private void Update()
    {
        transform.position = new Vector3(jucator.position.x, transform.position.y, transform.position.z);
        uiteInFata = Mathf.Lerp(uiteInFata, (distInFata * transform.localScale.x), Time.deltaTime * vitezaCamera);
    }
}
