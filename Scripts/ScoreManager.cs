using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text strength_text;
    public Text intelligence_text;
    private float lastTime;
    private float currentTime;
    private int strength;

    // Start is called before the first frame update
    void Start()
    {
        lastTime = Time.time;
        strength = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        if(currentTime - lastTime >= 3)
        {
            strength += 3;
            strength_text.text = strength.ToString();
            lastTime = currentTime;
        }
        intelligence_text.text = Time.time.ToString();
    }
}
