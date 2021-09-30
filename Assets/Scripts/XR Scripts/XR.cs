using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;

public class XR : MonoBehaviour
{
    public Canvas CanvasObject;
    public GameObject HUD;
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
                Vrbool = false;
                HUD.SetActive(true);
            }
            else
            {
                StartCoroutine(StartXR());
                Vrbool = true;
                CanvasObject.GetComponent<Canvas>().enabled = false;
                HUD.SetActive(false);
            }
        }

    }

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

    public void StopXR()
    {
        Debug.Log("Stopping XR...");
        XRGeneralSettings.Instance.Manager.StopSubsystems();
        XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        Debug.Log("XR stopped completely.");
    }
}