using UnityEngine;

public class dispenserSageti : MonoBehaviour
{
    [SerializeField] private float vitezaAtac;
    [SerializeField] private Transform punctAtac;
    [SerializeField] private GameObject[] sageti;
    private float timpAtac;

    private void Atac()
    {
        timpAtac = 0;

        sageti[gasesteProiectil()].transform.position = punctAtac.position;
        sageti[gasesteProiectil()].GetComponent<sagetiDispenser>().activareProiectil();
    }

    private void Update()
    {
        timpAtac += Time.deltaTime;
        if (vitezaAtac < timpAtac)
            Atac();

    }

    private int gasesteProiectil()
    {
        for (int i = 0; i < sageti.Length; i++)
            if (!sageti[i].activeInHierarchy)
                return i;
        return 0;
    }
}
