using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{   
    //static bool SinglePlayer;
    public void clicked(bool SinglePlayer)
    {   
        PongConfig.SinglePlayer = SinglePlayer;
        SceneManager.LoadScene("PongGame", LoadSceneMode.Single);
    }
    public void ChangeDifficulty(float value)
    {
        PongConfig.DifficultyLevel = value;
    }
}
