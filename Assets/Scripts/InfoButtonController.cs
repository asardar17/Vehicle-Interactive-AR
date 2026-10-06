using UnityEngine;

public class InfoButtonController : MonoBehaviour
{
    private GameObject infoPanel;

    void Start()
    {
        infoPanel = transform.parent.Find("InfoPanel").gameObject;
    }

    public void OpenInfo()
    {
        infoPanel.SetActive(true);
    }

    public void CloseInfo()
    {
        infoPanel.SetActive(false);
    }
}