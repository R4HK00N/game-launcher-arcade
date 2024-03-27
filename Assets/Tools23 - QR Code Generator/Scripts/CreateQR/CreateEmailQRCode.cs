using TMPro;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class CreateEmailQRCode : CreateQRCode
    {
        public TMP_InputField EmailAddressInputField;

        public void GenerateTextToConvert()
        {
            if (UIManager.Instance.isFormValid) GenerateText();
        }

        public override string GenerateText()
        {
            if (EmailAddressInputField.text != null) Lastresult += ("mailto:" + EmailAddressInputField.text);
            Debug.Log(Lastresult);
            return Lastresult;
        }
    }
}
