using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class XR : MonoBehaviour
{
    public bool ShowHUD;

    public GameObject HUD;
    public GameObject HUDVR;
    private bool Vrbool;

    void Start()
    {
        StopXR();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Vrbool)
            {
                StopXR();
                Vrbool = false;
            }
            else
            {
                StartCoroutine(StartXR());
                if (ShowHUD == true)
                {
                    HUDVR.SetActive(true);
                }
                
                HUD.SetActive(false);
                Vrbool = true;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            HUD.SetActive(true);
            HUDVR.SetActive(false);
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
        HUD.SetActive(true);
        HUDVR.SetActive(false);

    }

}