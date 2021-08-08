using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwith : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}