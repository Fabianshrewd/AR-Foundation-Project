using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.Json;
using System.Net;
using ExcelDataReader;
using System.IO;
using System.Data;

public class Excel_Textanzeigen : MonoBehaviour
{
    //Variablen
    public FileStream stream;
    public int Row;
    public GameObject obj1;

    public int Row2;
    private DataTable dt;
    private TextMeshPro myText;

    // Start is called before the first frame update
    void Start()
    {
        //Get the TextMesh Object
        myText = GetComponent<TextMeshPro>();

        //Excel Datei lesen
        stream = File.Open(Application.persistentDataPath + "/Sheet1.xlsx", FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        DataSet result = excelReader.AsDataSet();
        dt = result.Tables[0];

        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    double timer = 0;
    double timer_speed = 10;

    void Update()
    {
        if (timer > 2)
        {
            //Row information
            int selected_row = this.Row;

            //Text ändern
            myText.text += dt.Rows[0][0].ToString() + " " + dt.Rows[selected_row][0].ToString() + "\n" +
                dt.Rows[0][1].ToString() + " " + dt.Rows[selected_row][1].ToString() + "\n" +
                dt.Rows[0][2].ToString() + " " + dt.Rows[selected_row][2].ToString() + "\n" +
                dt.Rows[0][3].ToString() + " " + dt.Rows[selected_row][3].ToString();

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
