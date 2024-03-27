using UnityEngine;
using ZXing; 
using ZXing.QrCode;  
using UnityEngine.UI;  
using TMPro;
using System.Collections.Generic;
using System.IO;

namespace QRCodeGenerator23
{
    public class CreateQRCode : MonoBehaviour
    {
        public string Lastresult;
        public static Texture2D encoded;
        public Image QRCodePlaceHolder;

        public List<TMP_InputField> inputFields;
        public CanvasGroup QRCodeImageCanvas;

        public virtual string GenerateText()
        {
            return Lastresult;
        }

        // For generating QRCode
        public static Color32[] Encode(string textForEncoding, int width, int height)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width
                }
            };
            return writer.Write(textForEncoding);
        }

        // For generating the QRCode Image
        public void GenerateQROutput()
        {
            if (UIManager.Instance.isFormValid)
            {
                encoded = new Texture2D(312, 312);
                var textForEncoding = Lastresult;
                if (textForEncoding != null)
                {
                    var color32 = Encode(textForEncoding, encoded.width, encoded.height);
                    encoded.SetPixels32(color32);
                    encoded.Apply();
                }

                QRCodePlaceHolder.sprite =
                    Sprite.Create(encoded, new Rect(0, 0, encoded.width, encoded.height), Vector2.zero);
            }
        }

        //On back button click this function allows the user to edit the form
        public void EnableEditFunction()
        {
            Lastresult = "";
            QRCodeImageCanvas.alpha = 0;
        }

        //used to share the image on web
        public void ShareImage()
        {
            Texture2D ss = encoded;

            string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
            File.WriteAllBytes(filePath, ss.EncodeToPNG());

            // To avoid memory leaks
            //Destroy(ss);

            //new NativeShare().AddFile(filePath)
                //.SetSubject("Subject goes here").SetText("Hello world!")
                //.SetUrl("https://github.com/yasirkula/UnityNativeShare")
                //.SetCallback((result, shareTarget) =>
                //    Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                //.Share();
        }
    }
}  