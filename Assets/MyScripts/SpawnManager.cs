using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SpawnManager : MonoSingleton<SpawnManager>
{
    [SerializeField] private int _currentWave;
    [SerializeField] private GameObject _mechContainer;
    [SerializeField] private List<GameObject> _mechs;
    [SerializeField] private GameObject _mechPrefab;
    [SerializeField] private bool _newWave;
    private int _hasDied;
    

    // Start is called before the first frame update
    void Start()
    {
        _mechs = MechGenerator(10);
        StartCoroutine(TestWave());
    }

    private List<GameObject> MechGenerator(int amountOfMechs)
    {
        for (int i = 0; i < amountOfMechs; i++)
        {
            GameObject mech = Instantiate(_mechPrefab);
            mech.transform.parent = _mechContainer.transform;
            _mechs.Add(mech);
            mech.SetActive(false);
        }
        return _mechs;
    }
    public GameObject RequestMech()
    {
        foreach (var mech in _mechs)
        {
            if (mech.activeInHierarchy == false)
            {
                mech.SetActive(true);
                return mech;
            }
        }

        GameObject newMech = Instantiate(_mechPrefab);
        newMech.transform.parent = _mechContainer.transform;
        _mechs.Add(newMech);
        return newMech;
    }

    private IEnumerator TestWave()
    {
        while (true)
        {
            switch (_currentWave)
            {
                case 0:
                    yield return new WaitForSeconds(5);
                    RequestMech();
                    if (Time.time >= 20)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 1:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 30)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 2:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 40)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 3:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 50)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 4:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 60)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 5:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 70)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 6:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 80)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 7:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 90)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 8:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 100)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 9:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 110)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 10:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.time >= 120)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;

            }
            if (_currentWave == 10)
            {
                Debug.Log("Finished ");
                break;
            }
        }
    }
}