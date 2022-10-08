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
    private byte[] raw;
    private System.Net.WebClient wc;
    private string ip_address;
    TextMeshPro myText;

    // Start is called before the first frame update
    void Start()
    {
        //Get the TextMesh Object
        myText = GetComponent<TextMeshPro>();

        try
        {
            using (var client = new WebClient())
            using (client.OpenRead("10.0.9.22:4567"))
            {
                ip_address = "http://10.0.9.22:4567/weasels";
            }
        }
        catch
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://fabiangranig.at/weasels"))
                {
                    ip_address = "https://fabiangranig.at/weasels";
                }
            }
            catch
            {
                //Nichts passiert
            }
        }
    }

    // Update is called once per frame
    double timer = 0;
    void Update()
    {
        if (timer > 2)
        {
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
            var u1 = root[0];
            var u2 = root[1];
            var u3 = root[2];

            //Create string values
            string sol = "Name: \t" + u1.GetProperty("weaselId") + "\n" + "Online: \t" + u1.GetProperty("online") + "\n" + "Position: \t" + u1.GetProperty("lastWaypoint") + "\n" + "Akku: \t" + u1.GetProperty("battery");

            //Put the text on the gameobject
            myText.text = sol;

            //Reset timer
            timer = 0;
        }
        else
        {
            timer += 1 * Time.deltaTime;
        }
    }
}
