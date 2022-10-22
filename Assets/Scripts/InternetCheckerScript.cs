using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;
using System.Net;
using System.Threading;

public class InternetCheckerScript : MonoBehaviour
{
    //Right ip address
    public string checked_ip_address;
    private Thread thread1;

    // Start is called before the first frame update
    void Start()
    {
        thread1 = new Thread(NetworkCheck);
        thread1.Start();
    }

    private void NetworkCheck()
    {
        CheckIP("https://fabiangranig.at/weasels");
        CheckIP("http://10.0.9.22:4567/weasels");
    }

    private void CheckIP(string ip)
    {
        try
        {
            //Check if Website is here
            HttpWebRequest request = WebRequest.Create(ip) as HttpWebRequest;
            request.Method = "HEAD";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            HttpStatusCode status = response.StatusCode;
            Debug.Log("Up: " + ip);
            checked_ip_address = ip;
        }
        catch
        {
            Debug.Log("Down: " + ip);
        }
    }
}
