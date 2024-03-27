using UnityEngine;

namespace QRCodeGenerator23
{
    public class CreateGeoLocationQRCode : CreateQRCode
    {
        public void GenerateTextToConvert()
        {
            if (UIManager.Instance.isFormValid) GenerateText();
        }

        public override string GenerateText()
        {
            Lastresult += ("geo:" + inputFields[0].text + "," + inputFields[1].text + "?q=" + inputFields[2].text);
            Debug.Log(Lastresult);
            return Lastresult;
        }
    }
}
