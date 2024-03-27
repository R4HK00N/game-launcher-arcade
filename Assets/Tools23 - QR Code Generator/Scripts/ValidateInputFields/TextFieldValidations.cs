using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class TextFieldValidations : MonoBehaviour
    {
        public List<TMP_InputField> InputFields;
        [SerializeField] private bool isFormInputFieldOkay = true;
        public List<GameObject> ErrorSigns;

        public void ValidateInputFields()
        {
            if (string.IsNullOrEmpty(InputFields[0].text))
            {
                isFormInputFieldOkay = false;
                ErrorSigns[0].gameObject.SetActive(true);
                Handheld.Vibrate();
            }
            else
            {
                ErrorSigns[0].gameObject.SetActive(false);
            }

            if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
            isFormInputFieldOkay = true;
        }
    }
}
