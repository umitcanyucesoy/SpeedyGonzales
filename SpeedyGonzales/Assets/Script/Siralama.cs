using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Siralama : MonoBehaviour
{
    public int AktifYonSirasi = 1;
    SiralamaYonetim siralama;
    LapYonetim lapyonetim;
    Genelayarlar genelayarlar;
    public int pozisyon;
    public int LapStep;
    void Start()
    {
        LapStep = 1;
        genelayarlar = GameObject.FindWithTag("OyunKontrol").GetComponent<Genelayarlar>();
        genelayarlar.kendinigonder(gameObject);



        if (genelayarlar.haritaminturu.ToString() == "Tur")
        {
            lapyonetim = GameObject.FindWithTag("OyunKontrol").GetComponent<LapYonetim>();


        }
        else
        {
            siralama = GameObject.FindWithTag("OyunKontrol").GetComponent<SiralamaYonetim>();
            siralama.kendinigonder(gameObject, AktifYonSirasi);
        }





    }

    private void OnTriggerEnter(Collider other)
    {

        if (genelayarlar.haritaminturu.ToString() == "Yaris")
        {
            if (other.CompareTag("GidisYonuObje"))
            {
                AktifYonSirasi = int.Parse(other.transform.gameObject.name);
                siralama.siralamaGuncelle(gameObject, AktifYonSirasi);

            }

        }




        if (gameObject.name == "Biz")
        {
            if (other.CompareTag("Finish"))
            {

                if (genelayarlar.haritaminturu.ToString() == "Tur")
                {

                    GetComponentInParent<CarController>().YonGidisİndex = 0;
                    AktifYonSirasi = 1;

                    if (LapStep < 3)
                    {
                        LapStep++;
                        lapyonetim.Lapkontrolet(LapStep);

                    }
                    else
                    {
                        lapyonetim.Lapgonder(gameObject);
                        genelayarlar.OyunSonu(pozisyon);
                    }



                }
                else
                {
                    genelayarlar.OyunSonu(pozisyon);
                }




            }

        }


    }



}
