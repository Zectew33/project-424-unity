using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class XR : MonoBehaviour
{
    //public GameObject[] HUD;
    //public GameObject[] HUDVR;

    public GameObject HUD;
    public GameObject HUDVR;
    private bool Vrbool;

    void Start()
    {
        StopXR();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Vrbool)
            {
                StopXR();
                //ShowObject(HUD, true);
                //ShowObject(HUDVR, false);
                HUD.SetActive(true);
                HUDVR.SetActive(false);
                Vrbool = false;
            }
            else
            {
                StartCoroutine(StartXR());
                //ShowObject(HUD, false);
                //ShowObject(HUDVR, true);
                HUD.SetActive(false);
                HUDVR.SetActive(true);
                Vrbool = true;
            }
        }

    }


    //Enables XR (VR)
    public IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed. Check Editor or Player log for details.");
        }
        else
        {
            Debug.Log("Starting XR...");
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }
    }

    //Disables XR (VR)
    public void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
       
        Debug.Log("XR stopped completely.");

    }

    //Enables or Disables an Array of Objects
    private void ShowObject(GameObject[] item, bool state)
    {
        for(int i = 0; i < item.Length; i++)
        {
            item[i].SetActive(state);
        }
    }

}