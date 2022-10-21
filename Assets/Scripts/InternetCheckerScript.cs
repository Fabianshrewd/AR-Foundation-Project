using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;
using System.Net;

public class InternetCheckerScript : MonoBehaviour
{
    //Right ip address
    public string checked_ip_address;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // create the request
            HttpWebRequest request2 = WebRequest.Create("http://10.0.9.22:4567/weasels") as HttpWebRequest;
            request2.Method = "HEAD";
            HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse;
            HttpStatusCode status2 = response2.StatusCode;
            checked_ip_address = "http://10.0.9.22:4567/weasels";
        }
        catch
        {
            try
            {
                //Test1
                HttpWebRequest request = WebRequest.Create("https://fabiangranig.at/weasels") as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                HttpStatusCode status = response.StatusCode;
                checked_ip_address = "https://fabiangranig.at/weasels";
            }
            catch
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
