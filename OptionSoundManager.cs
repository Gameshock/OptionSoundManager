using UnityEngine;
using UnityEngine.UI;

public class OptionSoundManager : MonoBehaviour
{
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _bgmVolumeSlider;
    [SerializeField] private Slider _seVolumeSlider;

    public const string MasterVolumeKey = "MasterVolume";
    public const string BGMVolumeKey = "BGMVolume";
    public const string SEVolumeKey = "SEVolume";


    private void Start()
    {
        LoadVolumes();
    }

    /// <summary>
    /// 設定されたボリュームを呼び出し
    /// </summary>
    private void LoadVolumes()
    {
        // playerPrefsから値取得
        SoundManager.Instance.masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey, 0.5f);
        SoundManager.Instance.bgmMasterVolume = PlayerPrefs.GetFloat(BGMVolumeKey, 1.0f);
        SoundManager.Instance.seMasterVolume = PlayerPrefs.GetFloat(SEVolumeKey, 1.0f);

        // スライダーに値を設定
        _masterVolumeSlider.value = SoundManager.Instance.masterVolume;
        _bgmVolumeSlider.value = SoundManager.Instance.bgmMasterVolume;
        _seVolumeSlider.value = SoundManager.Instance.seMasterVolume;
    }

    /// <summary>
    /// 初期ボリュームにリセット
    /// </summary>
    public void OnResetVolumes()
    {
        // playerPrefsの値初期にリセット
        PlayerPrefs.SetFloat(MasterVolumeKey, 0.5f);
        PlayerPrefs.SetFloat(BGMVolumeKey, 1.0f);
        PlayerPrefs.SetFloat(SEVolumeKey, 1.0f);

        // playerPrefsから値取得
        SoundManager.Instance.masterVolume = PlayerPrefs.GetFloat(MasterVolumeKey);
        SoundManager.Instance.bgmMasterVolume = PlayerPrefs.GetFloat(BGMVolumeKey);
        SoundManager.Instance.seMasterVolume = PlayerPrefs.GetFloat(SEVolumeKey);

        // スライダーに値を設定
        _masterVolumeSlider.value = SoundManager.Instance.masterVolume;
        _bgmVolumeSlider.value = SoundManager.Instance.bgmMasterVolume;
        _seVolumeSlider.value = SoundManager.Instance.seMasterVolume;
    }

    /// <summary>
    /// マスターボリュームの変更
    /// </summary>
    public void OnChangeMasterVolume()
    {
        AudioListener.volume = _masterVolumeSlider.value;

        SoundManager.Instance.BgmAudioSource.volume = _bgmVolumeSlider.value * _masterVolumeSlider.value;
        SoundManager.Instance.SeAudioSource.volume = _seVolumeSlider.value * _masterVolumeSlider.value;

        PlayerPrefs.SetFloat(MasterVolumeKey, _masterVolumeSlider.value);
    }

    /// <summary>
    /// BGMボリュームの変更
    /// </summary>
    public void OnChangeBgmVolume()
    {
        SoundManager.Instance.bgmMasterVolume = _bgmVolumeSlider.value;

        SoundManager.Instance.BgmAudioSource.volume = _bgmVolumeSlider.value * _masterVolumeSlider.value;

        PlayerPrefs.SetFloat(BGMVolumeKey, _bgmVolumeSlider.value);
    }

    /// <summary>
    /// SEボリュームの変更
    /// </summary>
    public void OnChangeSeVolume()
    {
        SoundManager.Instance.seMasterVolume = _seVolumeSlider.value;

        SoundManager.Instance.SeAudioSource.volume = _seVolumeSlider.value * _masterVolumeSlider.value;

        PlayerPrefs.SetFloat(SEVolumeKey, _seVolumeSlider.value);
    }
}
