using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QRCodeGenerator23
{
    public class GeoLocationInputFieldValidations : MonoBehaviour
    {
        public List<TMP_InputField> InputFields;
        public List<GameObject> ErrorSigns;

        [SerializeField] private bool isFormInputFieldOkay = true;

        //You can comment out the code inside the ValidateInputFields() if you don't want to validate the inputs
        public void ValidateInputFields()
        {
            for (int i = 0; i < InputFields.Count - 1; i++) //only valiating the latitude and longitude, so you must give them as input
            {
                isFormInputFieldOkay = (isFormInputFieldOkay) && Validate(InputFields[i].text);
                if (!isFormInputFieldOkay)
                {
                    ErrorSigns[i].gameObject.SetActive(true);
                    Handheld.Vibrate();
                    break;
                }
                else
                {
                    ErrorSigns[i].gameObject.SetActive(false);
                }
            }

            if (isFormInputFieldOkay) UIManager.Instance.isFormValid = true;
            isFormInputFieldOkay = true;

        }

        public bool Validate(string input)
        {
            if (!string.IsNullOrEmpty(input)) return true;
            return false;
        }
    }
}
