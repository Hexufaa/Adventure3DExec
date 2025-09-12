using UnityEngine;

public class triggertest : MonoBehaviour
{
    public GameObject objetoParaAtivar;

    private void Start()
    {
        if (objetoParaAtivar != null)
            objetoParaAtivar.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou na trigger: " + other.name);

        if (objetoParaAtivar != null)
            objetoParaAtivar.SetActive(true);
    }
}
