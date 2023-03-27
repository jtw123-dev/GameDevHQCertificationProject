using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Text _wavesText;
    private int _waveNumber;

    [SerializeField] private Text _warFundsText;
    // public Text warFundsText;
    [SerializeField] private int _currentWarFunds;
    [SerializeField] private Text _livesText;
   [SerializeField] private int _lives;
    [SerializeField] private Text _statusText;
    public override void Init()
    {
        base.Init();
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

    public void UpdateLives()
    {
        _lives--;
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

        else if (_lives<=0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateWaves()
    {
        _waveNumber++;
        _wavesText.text = _waveNumber.ToString() + " /10";
    }

    public bool UpdateWarFundsAfterTowerBuy(int towerCost)
    {
        if ( _currentWarFunds>=towerCost)
        {
            Debug.Log("update funds was called");
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
        Debug.Log("updated funds");
        _currentWarFunds += prize;
        _warFundsText.text = _currentWarFunds.ToString();
    }

}
