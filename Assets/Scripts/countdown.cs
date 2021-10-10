using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    private float _countdown = 4f;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
    }

    void Update()
    {
        // start Countdown an Destroy self
        _countdown -= Time.deltaTime;
        GetComponent<Text>().text = _countdown > 3.5f ? " " : _countdown.ToString("0");

        if(_countdown <= 0.5 )
        {   
            _countdown = 0;
            GetComponent<Text>().gameObject.SetActive(false);
            isPaused = false;
            FindObjectOfType<BallScore>().ResetBall();
            Destroy(this);
        }
    }
}
