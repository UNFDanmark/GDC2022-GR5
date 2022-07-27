using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public int sceneTimer = 30;
    float counter = 0, buffermax = 180, buffer = 0;
    public RawImage bg, wave;
    Color cB, cW;

    private void Start()
    {
        cB = bg.color;
        cW = wave.color;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(counter >= sceneTimer)
        {
            if(buffer >= buffermax)
            {
                SceneManager.LoadScene("main scene backup");

            }
            else
            {
                Debug.Log(wave.color.a);
                cB.a -= 0.01f;
                cW.a -= 0.01f;
                
                bg.color = cB;
                wave.color = cB;


                buffer++;
            }
        }
    }
}
