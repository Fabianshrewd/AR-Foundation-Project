using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.Json;
using System.Net;

public class ChangeText2 : MonoBehaviour
{
    public int weasel_id_outside;
    private byte[] raw;
    private System.Net.WebClient wc;
    private string ip_address;
    TextMeshPro myText;

    // Start is called before the first frame update
    void Start()
    {
        //Get the TextMesh Object
        myText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    double timer = 0;
    double timer_speed = 10;
    void Update()
    {
        if (timer > 2)
        {
            //Get the ip address
            ip_address = GameObject.Find("InternetChecker").GetComponent<InternetCheckerScript>().checked_ip_address;

            //Get the information from the weasel webserver
            System.Net.WebClient wc = new System.Net.WebClient();

            //Main address: http://10.0.9.22:4567/weasels //Backup address: https://fabiangranig.at/weasels
            byte[] raw = wc.DownloadData(ip_address);

            //Convert in an string
            string webData = System.Text.Encoding.UTF8.GetString(raw);

            //Create the JSON Document
            using JsonDocument doc = JsonDocument.Parse(webData);
            JsonElement root = doc.RootElement;

            //Weasels aufteilen
            var u1 = root[weasel_id_outside];

            //Create string values
            string sol = "Name: \t" + u1.GetProperty("weaselId") + "\n" + "Online: \t" + u1.GetProperty("online") + "\n" + "Position: \t" + u1.GetProperty("lastWaypoint") + "\n" + "Akku: \t" + u1.GetProperty("battery");

            //Put the text on the gameobject
            myText.text = sol;

            //Reset timer
            timer_speed = 1;
            timer = 0;
        }
        else
        {
            timer += timer_speed * Time.deltaTime;
        }
    }
}
