using UnityEngine;
using UnityEngine.SceneManagement;

namespace QRCodeGenerator23
{
    public class SceneLoader : MonoBehaviour
    {
        public void SceneChange(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
