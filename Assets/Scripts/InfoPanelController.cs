using UnityEngine;
using TMPro;

public class InfoPanelController : MonoBehaviour
{
    public GameObject infoPanel;
    public TMP_Text vehicleName;
    public TMP_Text vehicleSpecs;

    public void OpenPanel()
    {
        infoPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }

    public void SetVehicleInfo(string name, string specs)
    {
        vehicleName.text = name;
        vehicleSpecs.text = specs;
    }
}