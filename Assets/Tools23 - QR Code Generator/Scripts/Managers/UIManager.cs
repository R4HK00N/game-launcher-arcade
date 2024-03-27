using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QRCodeGenerator23
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public bool isFormValid = false;
        public bool isWIFINoEncryptionEnabled = false;
        public GameObject Form;
        public Button HomeButton;
        public CanvasGroup QRCanvasGroup;

        #region Singleton region

        public void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        #endregion

        public void OnGenerateButtonClicked()
        {
            if (isFormValid)
            {
                HomeButton.gameObject.SetActive(false);
                Form.gameObject.SetActive(false);
                FadeIn(QRCanvasGroup);
            }
        }

        public void GenerateAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnBackButtonClicked()
        {
            HomeButton.gameObject.SetActive(true);
            Form.gameObject.SetActive(true);
            QRCanvasGroup.alpha = 0;
            QRCanvasGroup.transform.localScale = Vector3.zero;
        }

        public void FadeIn(CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1;
            //canvasGroup.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
        }
    }
}