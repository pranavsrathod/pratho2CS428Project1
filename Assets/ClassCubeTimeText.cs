using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
// using System.datetime;
using TMPro;

public class ClassCubeTimeText : MonoBehaviour
{
    public GameObject classCubeTimeText;
    string url = "http://worldtimeapi.org/api/timezone/Europe/London";
    // Start is called before the first frame update
    void Start()
    {
        // wait a couple seconds to start and then refresh every 10 seconds

       InvokeRepeating("GetDataFromWeb", 2f, 10f);
    }

    // Update is called once per frame
    void GetDataFromWeb(){
        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.result ==  UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log ("TIME JSON File For JSON FILE");
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);

                // // this code will NOT fail gracefully, so make sure you have
                // // your API key before running or you will get an error
                var startDate = webRequest.downloadHandler.text.IndexOf("datetime", 0);
                var endDate = webRequest.downloadHandler.text.IndexOf(",", startDate);
                var temp = webRequest.downloadHandler.text.Substring((startDate + 22), (endDate - startDate - 39));
                Debug.Log(temp);

                // string hh = temp.Substring(0, temp.IndexOf(":"));
                // Debug.Log(hh);
                // string mm = temp.Substring(temp.IndexOf(":")+1);
                // Debug.Log(mm);

                // int hours = Int32.Parse(hh);
                // string half;
                // if (hours > 12) {
                //     hours = hours - 12;
                //     half = "PM";
                // } else {
                //     half = "AM";
                // }
            	// // grab the current temperature and simplify it if needed
            	// int startTemp = webRequest.downloadHandler.text.IndexOf("temp",0);
            	// int endTemp = webRequest.downloadHandler.text.IndexOf(",",startTemp);
				// double tempF = float.Parse(webRequest.downloadHandler.text.Substring(startTemp+6, (endTemp-startTemp-6)));
				// int easyTempF = Mathf.RoundToInt((float)tempF);
                // //Debug.Log ("integer temperature is " + easyTempF.ToString());
                // int startConditions = webRequest.downloadHandler.text.IndexOf("main",0);
                // int endConditions = webRequest.downloadHandler.text.IndexOf(",",startConditions);
                // string conditions = webRequest.downloadHandler.text.Substring(startConditions+7, (endConditions-startConditions-8));
                // //Debug.Log(conditions);
                // classCubeTimeText.GetComponent<TextMeshPro>().text = "" + hours + ":" + mm + " " + half;
                classCubeTimeText.GetComponent<TextMeshPro>().text = "" + temp;
                // weatherTextObject.GetComponent<TextMeshPro>().text = "" + easyTempF.ToString() + "°F\n" + conditions;
            }
        }
    }
}
