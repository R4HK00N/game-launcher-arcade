using TMPro;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class CreateSMSQRCode : CreateQRCode
    {
        public TMP_InputField PhoneNumberInputField;
        public TMP_InputField MessageInputField;

        public void GenerateTextToConvert()
        {
            if (UIManager.Instance.isFormValid) GenerateText();
        }

        public override string GenerateText()
        {
            Lastresult += ("smsto:" + PhoneNumberInputField.text + ":" + MessageInputField.text);
            Debug.Log(Lastresult);
            return Lastresult;
        }
    }
}
