using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Top : MonoBehaviour
{
    Rigidbody2D topRb;
    SpriteRenderer topRenderer;
    [SerializeField] float ziplamaGucu;
    [SerializeField] Color[] colors = new Color[6];
    [SerializeField] Text puanYazisi, rekorPuanYazisi;
    [SerializeField] AudioSource topKenarEtkilesimiSesi;
    int puan, rekorPuan;
    void Start()
    {
        topRb = GetComponent<Rigidbody2D>();
        topRenderer = GetComponent<SpriteRenderer>();
        if(PlayerPrefs.HasKey("Rekor"))
        {
           rekorPuan = PlayerPrefs.GetInt("Rekor");
           rekorPuanYazisi.text = "Rekor : " + rekorPuan;
        }
        else
        {
            rekorPuan = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D temas)
    {
        if(temas.gameObject.tag == "Zemin")
        {
            topRb.AddForce(Vector2.up * ziplamaGucu / 2, ForceMode2D.Impulse);
        }

        if(temas.gameObject.tag == "Kenar")
        {
            topRb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse);

            if(topRenderer.color == temas.gameObject.GetComponent<SpriteRenderer>().color)
            {
                puan += Random.Range(3, 8);
                puanYazisi.text = "Puan : " + puan;
                topKenarEtkilesimiSesi.Play();

                if(puan > rekorPuan)
                {
                    rekorPuan = puan;
                    rekorPuanYazisi.text = "Rekor : " + puan;
                    PlayerPrefs.SetInt("Rekor", rekorPuan);
                }
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D temas)
    {
        if(temas.gameObject.tag == "RenkDegistirici")
        {
            RenkDegistir();
        }
    }

    void RenkDegistir()
    {
        int rastgele = Random.Range(0,6);
        switch (rastgele)
        {
            case 0 : 
                topRenderer.color = colors[0];
                break;
            case 1 :
                topRenderer.color = colors[1];
                break;
            case 2 :
                topRenderer.color = colors[2];
                break;
            case 3 :
                topRenderer.color = colors[3];
                break;
            case 4 :
                topRenderer.color = colors[4];
                break;
            case 5 :
                topRenderer.color = colors[5];
                break;
        }
    }
}
