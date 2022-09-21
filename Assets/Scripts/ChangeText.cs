using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
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
        //Get the information
        System.Net.WebClient wc = new System.Net.WebClient();
        byte[] raw = wc.DownloadData("http://fabiangranig.at/info.txt");

        //Convert in an string
        string webData = System.Text.Encoding.UTF8.GetString(raw);

        //Put the text on the gameobject
        myText.text = webData;
    }
}
