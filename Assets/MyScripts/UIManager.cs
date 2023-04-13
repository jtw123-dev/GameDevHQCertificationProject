using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Text _wavesText;
    private int _waveNumber =1;
    [SerializeField] private Text _warFundsText;
    [SerializeField] private int _currentWarFunds;
    [SerializeField] private Text _livesText;
    [SerializeField] private int _lives;
    [SerializeField] private Text _statusText;

    private void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }

        if (_lives <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void Play()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        
    }

    public void FastForward()
    {
        Time.timeScale = 2;
    }

    public void UpdateLives(int livesToSubtract)
    {
        _lives-=livesToSubtract;
        _livesText.text = _lives.ToString();

        if (_lives>60)
        {
            _statusText.color = Color.blue;
            _statusText.text = "Good";
        }
        else if (_lives>20)
        {
            _statusText.color = Color.yellow;
            _statusText.text = "Moderate";
        }

        else if (_lives<20)
        {
            _statusText.color = Color.red;
            _statusText.text = " Danger";
        }
    }

    public void UpdateWaves()
    {
        _waveNumber++;
        _wavesText.text = _waveNumber.ToString() + " /10";

        if (_waveNumber>10)
        {
            _wavesText.text = 10.ToString();
        }
    }

    public bool UpdateWarFundsAfterTowerBuy(int towerCost)
    {
        if ( _currentWarFunds>=towerCost)
        {
            _currentWarFunds -= towerCost;
            _warFundsText.text = _currentWarFunds.ToString();
            return true;
        }

        else if (_currentWarFunds<towerCost)
        {
            return false;
        }
        return false;     
    }

    public void UpdateWarFunds(int prize)
    {
        _currentWarFunds += prize;
        _warFundsText.text = _currentWarFunds.ToString();
    }
}
