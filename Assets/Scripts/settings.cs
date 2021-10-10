using UnityEngine;
public class settings
{
    [SerializeField]
    int _targetFrameRate = 60;

    public static bool SinglePlayer;
    public static float DifficultyLevel = 5f;

    void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }
}
