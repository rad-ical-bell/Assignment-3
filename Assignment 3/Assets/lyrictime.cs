using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTextEffects;

public class lyrictime : MonoBehaviour
{
    public TextEffect myText;
    public string textEffectName;
    public string textEffectName2;
    public string textEffectName3;
    void Start()
    {
        myText.StopManualEffects();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            myText.StartManualEffect(textEffectName);
            myText.StartManualEffect(textEffectName2);
            myText.StartManualEffect(textEffectName3);
        }
    }
}
