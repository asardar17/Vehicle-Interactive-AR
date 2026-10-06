using UnityEngine;
using TMPro;

public class VehicleInfoData : MonoBehaviour
{
    public string vehicleName;
    [TextArea(5, 10)]
    public string vehicleSpecs;

    public TMP_Text nameText;
    public TMP_Text specsText;

    public void ShowInfo()
    {
        nameText.text = vehicleName;
        specsText.text = vehicleSpecs;
    }
}