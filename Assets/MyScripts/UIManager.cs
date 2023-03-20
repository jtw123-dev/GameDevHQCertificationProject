using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Text _warFundsText;
    public Text warFundsText;
    public int totalWarFunds;
    public override void Init()
    {
        base.Init();
    }

    public void BuyTower()
    {

    }
}
