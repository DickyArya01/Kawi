﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poin : MonoBehaviour
{
    Player KomponenPlayer; // Variabel gerak dan Semua komponennya di Script Gerak
    // Start is called before the first frame update
    void Start()
    {
        KomponenPlayer = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fungsi ketika menyentuh enemies
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Player")
        {
            KomponenPlayer.Dewandaru++;
            Destroy(gameObject);
        }
    }
}
