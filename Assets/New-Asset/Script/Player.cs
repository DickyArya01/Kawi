using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Text info_Heart; // Variabel Heart
    Text info_Dewandaru; // Variabel untuk Koin
    public int kecepatan; //kecepatan gerak
    // 
    public int kekuatanlompat; //variabel kekuatan lompat

    public bool balik;
    public int pindah;

    Rigidbody2D lompat; //lompat sebagai nama dari Rigidbody2D

    //Variabel sensor tanah
    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    public int Heart; // Variabel nyawa Player
    public int Dewandaru; //Variabel Koin

    // // Start is called before the first frame update
    // //Animasi
    Animator anim; //sebagai vaiabel Animator

    Vector2 pplay; //variabel vector untuk posisi start
    public bool play_again; //Variabel nilai play kembali

    public GameObject UI_Win,UI_Lose; //variabel untuk menang dan kalah

    void Start()
    {
        lompat=GetComponent<Rigidbody2D>(); //inisialisasi awal untuk lompat
        anim=GetComponent<Animator>(); //Inisialisasi Componen Animasi
        pplay=transform.position; //start sebagai object transform posisi
        info_Heart = GameObject.Find("UI_Heart").GetComponent<Text>(); // Pendefinisian UI Heart sebagai componen Text
        info_Dewandaru = GameObject.Find("UI_Poin").GetComponent<Text>(); // Pendefinisian UI Coin sebagai componen Text
    }

    // Update is called once per frame
    void Update()
    {
    //     //Menampilkan Heart ke UI Heart
        info_Heart.text = "Heart : " + Heart.ToString(); //Heart yaitu Variabel di Atribut Player
    //     //Menampilkan Heart ke UI Coin
        info_Dewandaru.text = "Poin : " + Dewandaru.ToString(); //Coin yaitu Variabel di Atribut Player
    //     //Menampilkan Amo ke UI Amo
    //     info_Amo.text = "Amo : " + Amo.ToString(); //Amo Yaitu Variabel di Atribut Player

        //Logic Cek Point 1
        if(play_again == true)
        {
            transform.position = pplay;
            play_again=false; 
        }

        //Logik Heart 
        if(Heart <= 0)
        {
            //Destroy(gameObject);
            UI_Lose.SetActive(true); // UI Kalah aktif
        }
        else if (Dewandaru >= 2)
        {
            UI_Win.SetActive(true); //UI Menang Aktif
        }

        //Logik untuk Animasi
        if(tanah == false)
        {
            anim.SetBool("Lompat", true);
        }
        else
        {
            anim.SetBool("Lompat", false);
        }

        //sensor tanah
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);
    //     //control player
        if (Input.GetKey (KeyCode.D)) //Key D untuk bergerak ke kanan
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime); 
            pindah=1;
            anim.SetBool("Lari", true); //animasi lari
        }
        else if (Input.GetKey (KeyCode.A)) //key A untuk bergerak ke kiri
        {
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah=-1;
            anim.SetBool("Lari", true); //aimasi lari
        }
        else
        {
            anim.SetBool("Lari", false); //Tidak Berlari
            //anim.SetBool("Sliding", false);
          
        }


    //     //lompat dengan klik mouse kiri
        if(tanah==true && Input.GetKey(KeyCode.W)) //Mouse0 = klik kiri Mouse1=Klik Kanan
        {
            lompat.AddForce(new Vector2(0,kekuatanlompat));
        }
    //     //Lompat dengan Button Lompat
    //     if(tanah==true && (Button_lompat==true))
    //     {
    //         lompat.AddForce(new Vector2(0,kekuatanlompat));
    //     }
        
        //logik balik badan
        if(pindah > 0 && !balik)
        {
            flip();
        }
        else if(pindah < 0 && balik)
        {
            flip();
        }

    

    //fungsi balik badan
        void flip()
        {
            balik = !balik;
            Vector3 Player = transform.localScale;
            Player.x *= -1;
            transform.localScale = Player;
        }

    }
}
