using TMPro;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class CreateTextQRCode : CreateQRCode
    {
        public TMP_InputField TextInputField;

        public void GenerateTextToConvert()
        {
            if (UIManager.Instance.isFormValid) GenerateText();
        }

        public override string GenerateText()
        {
            Lastresult += TextInputField.text;
            Debug.Log(Lastresult);
            return Lastresult;
        }
    }
}
