using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{   
    //static bool SinglePlayer;
    public void clicked(bool SinglePlayer)
    {   
        settings.SinglePlayer = SinglePlayer;
        SceneManager.LoadScene("PongGame", LoadSceneMode.Single);
    }
    public void ChangeDifficulty(float value)
    {
        settings.DifficultyLevel = value;
    }
}
