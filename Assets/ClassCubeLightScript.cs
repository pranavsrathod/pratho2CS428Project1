using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassCubeLightScript : MonoBehaviour
{
   public GameObject classCubeObject;
    public GameObject classCubeLightObject;
    private bool turntDown = false;
    private bool prevWasDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Dot(mergeCubeObject.transform.up, Vector3.down) > 0){
        //     Debug.Log("Right Side UP!");

        // }
        // https://answers.unity.com/questions/1003884/how-to-check-if-an-object-is-upside-down.html
        // Debug.Log(" Dot Product : " + Vector3.Dot(mergeCubeObject.transform.up, Vector3.down));
         
         if ((Vector3.Dot(classCubeObject.transform.up, Vector3.down) > 0) && (turntDown == false) ){
            
            // turntDown = true;

            Debug.Log(classCubeLightObject.GetComponent<Light>().color);


        //  }
           
            Debug.Log("UPSIDE DOWN");
            // string color = "" + mergeCubeLightObject.GetComponent<Light>().color;
            if (classCubeLightObject.GetComponent<Light>().intensity == 10){
                Debug.Log("Increasing Intensity ");
                classCubeLightObject.GetComponent<Light>().intensity = 1000;
                // mergeCubeLightObject.GetComponent<Light>().color = Color.blue;
                turntDown = true;
            } else {
                // mergeCubeLightObject.GetComponent<Light>().color = Color.red;
                classCubeLightObject.GetComponent<Light>().intensity = 10;
                Debug.Log("Decreasing the Intensity");
                turntDown = true;
            }
            // if (turntDown && !prevWasDown){
            //     mergeCubeLightObject.GetComponent<Light>().color = Color.red;
            //     turntDown = !turntDown;
            // } else {
            //     mergeCubeLightObject.GetComponent<Light>().color = Color.blue;
            //     turntDown = !turntDown;
            // }
            //  prevWasDown = true;
         }
         else if (!(Vector3.Dot(classCubeObject.transform.up, Vector3.down) > 0) && (turntDown == true)){
            turntDown = false;
         }
    }
}
