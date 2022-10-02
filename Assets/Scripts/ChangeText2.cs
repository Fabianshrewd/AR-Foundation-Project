using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.Json;

public class ChangeText2 : MonoBehaviour
{
    TextMeshPro myText;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get the information from the weasel webserver
        System.Net.WebClient wc = new System.Net.WebClient();

        //Main address: http://10.0.9.22:4567/weasels //Backup address: https://fabiangranig.at/weasels
        byte[] raw = wc.DownloadData("https://fabiangranig.at/weasels");

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
        string sol = "Name: " + u1.GetProperty("weaselId") + "\n" + "last Waypoint: " + u1.GetProperty("lastWaypoint");

        //Put the text on the gameobject
        myText.text = sol;
    }
}
