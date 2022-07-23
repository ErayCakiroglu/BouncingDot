using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yonetici : MonoBehaviour
{
    [SerializeField] GameObject altigen, top, baslangicYazisi;
    [SerializeField] Transform baslangicPozisyonu;
    bool basla = false;
    void Start()
    {
        altigen.GetComponent<Donus>().enabled = false;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !basla)
        {
            top.transform.position = baslangicPozisyonu.position;
            top.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            altigen.GetComponent<Donus>().enabled = true;
            baslangicYazisi.SetActive(false);
            basla = true;
        }
    }
}
