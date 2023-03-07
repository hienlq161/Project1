using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloneSaoBang : MonoBehaviour  
{
    GameObject saoBang;
    [SerializeField] float CloneSpeed = 10;
    private void Awake()
    {
        saoBang = GameObject.FindGameObjectWithTag("SaoBang");
        transform.position = saoBang.transform.position;
    }

    void Update()
    {
        saoBang.GetComponent<SaoBang>().Move(gameObject.transform, CloneSpeed);
    }
}
