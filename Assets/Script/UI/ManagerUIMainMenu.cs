using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerUIMainMenu : MonoBehaviour
{
    [SerializeField] private Image _soundVolume;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioSource _audioSource;
    private bool _isSoundVolume = false;
    public void StarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
    }

    public void ExitGame()
    {
        Application.Quit();       
    }

    public void SoundVolume ()
    {
        _isSoundVolume = !_isSoundVolume;
        if (_isSoundVolume)
           _soundVolume.gameObject.SetActive(true);
        else _soundVolume.gameObject.SetActive(false);
    }

    private void SettingsSoundVolume()
    {
        _audioSource.volume = _volumeSlider.value;
        PlayerPrefs.SetFloat("SoundValue", _volumeSlider.value);
    }

}
