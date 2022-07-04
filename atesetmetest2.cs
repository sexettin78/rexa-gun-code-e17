using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class atesetmetest2 : MonoBehaviour
{
    public Text uyaritext;
     public float hiz = 0.1f;
    public Text mermisayitext;
    public float mermi, sarjor, sarjorsayi, menzil, hasar1, hasar2;
    public bool ates;
    RaycastHit hit;
    int dusmancani = 100;
    float floatzaman;
    int sayac;
    public Text zamantext;
    public GameObject panell;
    public GameObject panell2;
    public GameObject panell3;
    public GameObject panell4;         
    void Start()
    {
        
    }
    

   private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            panell.gameObject.SetActive(true);      
            panell2.gameObject.SetActive(false);     
            panell3.gameObject.SetActive(false);     
            panell4.gameObject.SetActive(false);        
         }
        

    }

    void Update()
    {
        mermisayitext.text = "Kalan Mermi:"+mermi.ToString();


          zamanyazdir();
      //  zamantext.text = "Zaman:" + sayac.ToString() + "sn";
        
        zamantext.text = "Zaman:" + sayac.ToString() + "sn";
        if (sayac == 15)
        {
            uyaritext.text = "Alp: Hızlı ol Furkan, farkedileceksin";
        }
        else if (sayac == 20)
        {
            SceneManager.LoadScene(39);
        }
    }

    public void atesevent(){
        if (mermi > 0)
        {
        mermi--;
        ates = true; 
        }
        else
        {
            uyaritext.text = "Merminiz bitti";
        }

    }
       void zamanyazdir()
    {
        floatzaman += Time.deltaTime;
        if (floatzaman > 1)
        {
            sayac++;
            floatzaman = 0;
        }
    }


    public void Relo1(){
        SceneManager.LoadScene(35);
    }
int bsrvurus = 0;
    void FixedUpdate(){
        if (ates)
        {
            ates = false;
            if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit , menzil))
            {
                if (hit.transform.tag == "dusman")
                {
                   
                    if (dusmancani < 1)
                    {
                        Destroy(hit.transform.gameObject);
                                    PlayerPrefs.SetInt("level", 18);
          
                        SceneManager.LoadScene(40);
                    }
                    else{
                    dusmancani -= 25;
                    bsrvurus += 1;
                   // Debug.Log("Düşmana değdi");
                    //uyaritext.text = "Başarılı Vuruş: "+bsrvurus.ToString();
                    }
                }
            }
        }  
    }




}
