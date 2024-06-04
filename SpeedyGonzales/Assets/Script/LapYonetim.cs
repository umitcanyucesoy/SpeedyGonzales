using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;



public class LapYonetim : MonoBehaviour
{
    public List<GameObject> arabalar = new List<GameObject>();
    public TextMeshProUGUI sira;
    private void Start()
    {
        sira.text = "1/3";
    }
    public void Lapgonder(GameObject gelenobje)
    {
        if (gelenobje.name=="Biz")
        {
          gelenobje.GetComponent<Siralama>().pozisyon = arabalar.Count() + 1;

        }
        else
        {
            arabalar.Add(gelenobje);
        }
        
       


        
    }

  

    public void Lapkontrolet(int lapstep)
    {
        sira.text = lapstep+"/3";

    }

}
