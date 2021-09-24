using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToMenu : MonoBehaviour
{
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
