using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadTuto : MonoBehaviour
{
    public GameObject tutoBegin;
    public Animator bais;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsynchronously());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation loading = new AsyncOperation();
        yield return new WaitForSeconds(5.5f);
        Debug.Log("tutorial activo");
        tutoBegin.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        bais.SetTrigger("go");
        yield return new WaitForSeconds(2.0f);
        tutoBegin.SetActive(false);
    }
}
