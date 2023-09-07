using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsModal : MonoBehaviour
{
    public Slider BgmSlider, SfxSlider;

    private void OnEnable()
    {
        BgmSlider.value = SoundCollection.instance.SourceBgm.volume;
        SfxSlider.value = SoundCollection.instance.SourceSfx.volume;
    }

    public void ChangeVolume(bool Sfx)
    {
        if (Sfx)
        {
            SoundCollection.instance.SourceSfx.volume = SfxSlider.value;
        }
        else
        {
            SoundCollection.instance.SourceBgm.volume = BgmSlider.value;
        }
    }
}
