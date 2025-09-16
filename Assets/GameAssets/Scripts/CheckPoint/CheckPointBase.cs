using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{

    public MeshRenderer MeshRenderer;
    public int key = 01;

    private bool checkpointActived = false;
    private string checkpointkey = "CheckPointKey";

    private void OnTriggerEnter(Collider other)
    {
        if (!checkpointActived && other.transform.tag == "Player")
        {

            CheckCheckPoint();

        }
    }

    private void CheckCheckPoint()
    {
        TurnItOn();
        SaveCheckPoiont();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn() 
    {
        MeshRenderer.material.SetColor("_EmissionColor", Color.white);
    }
    
    [NaughtyAttributes.Button]
    private void TurnItOff() 
    {
        MeshRenderer.material.SetColor("_EmissionColor", Color.grey);
    
    }

    private void SaveCheckPoiont()
    {
        //if(PlayerPrefs.GetInt(checkpointkey, 0) > key)    PlayerPrefs.SetInt(checkpointkey, key);

        CheckPointManager.Instance.saveCheckPoint(key);

        checkpointActived = true;
    }

}
