using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioAnalyser : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Text text;

    private float frequency = 0.0f;
    private int samplerate = 11024;

    private int testing = 1024;
    private int index = 0;
    private float amp = 0;

    void Update()
    {
        frequency = GetFundamentalFrequency();
        text.text = frequency.ToString();
    }

    private float GetFundamentalFrequency()
    {
        Debug.DrawLine(new Vector2(index * 0.01f, 0.0f), new Vector2(index * 0.01f, 10.0f), Color.green);
        Debug.DrawLine(new Vector2(0, amp), new Vector2(100.0f, amp), Color.red);
        float fundamentalFrequency = 0.0f;
        float[] data = new float[1024];
        audioSource.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);
        float s = 0.0f;
        int i = 0;
        Vector2 lastpos = new Vector2(0, data[0] * 100.0f);
        for (int j = 1; j < 1024; j++)
        {
            Vector2 pos = new Vector2(j * 0.01f, data[j] * 100.0f);

            Debug.DrawLine(pos, lastpos);
            lastpos = pos;
            if (s < data[j])
            {
                s = data[j];
                i = j;
            }
        }
        fundamentalFrequency = i * samplerate / 1024;
        for (int k = 240; k < 260; ++k)
            if (data[k] > 0.007f)
                fundamentalFrequency = 36;

        return fundamentalFrequency;
    }
}
