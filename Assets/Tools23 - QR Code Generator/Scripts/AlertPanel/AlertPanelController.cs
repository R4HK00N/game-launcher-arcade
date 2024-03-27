using UnityEngine;

namespace QRCodeGenerator23
{
    public class AlertPanelController : MonoBehaviour
    {
        public GameObject ButtonPanel;
        public GameObject Alertpanel;

        private string url = "https://assetstore.unity.com/packages/slug/248964";

        public void OnAlert()
        {
            ButtonPanel.SetActive(false);
            Alertpanel.SetActive(true);
        }

        public void Close()
        {
            Alertpanel.SetActive(false);
            ButtonPanel.SetActive(true);
        }

        public void OnPurchase()
        {
            //direct to the PRO version link
            Application.OpenURL(url);
        }
    }
}
