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
    [SerializeField] private GameObject[] _variousMechPrefabs;
    [SerializeField] private GameObject _levelComplete;
    [SerializeField] private int _currentMechs;
    [SerializeField] private GameObject _gameOverUI;

    private void OnEnable()
    {
        _mechs = MechGenerator(10);
        StartCoroutine(TestWave());
    }

    private List<GameObject> MechGenerator(int amountOfMechs)
    {
        for (int i = 0; i < amountOfMechs; i++)
        {
            if (_currentWave < 2)
            {
                GameObject mech = Instantiate(_variousMechPrefabs[0]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }
            else if (_currentWave == 2)
            {
                _currentMechs = 1;
                GameObject mech = Instantiate(_variousMechPrefabs[1]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }

            else if (_currentWave == 4)
            {
                _currentMechs = 2;
                GameObject mech = Instantiate(_variousMechPrefabs[2]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }

            else if (_currentWave == 6)
            {
                _currentMechs = 3;
                GameObject mech = Instantiate(_variousMechPrefabs[3]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }
            else if (_currentWave > 8)
            {
                _currentMechs = 4;
                GameObject mech = Instantiate(_variousMechPrefabs[4]);
                mech.transform.parent = _mechContainer.transform;
                _mechs.Add(mech);
                mech.SetActive(false);
            }
        }
        return _mechs;
    }

    public void Update()
    {

        if (_currentWave >= 10) //Time.timeSinceLevelLoad as time .time does not reset.
        {
            if (_mechs.All(m => m.activeInHierarchy == false))
            {
                _levelComplete.SetActive(true);
                _gameOverUI.SetActive(false);
            }
        }
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
        GameObject newMech = Instantiate(_variousMechPrefabs[_currentMechs]);
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
                    if (Time.timeSinceLevelLoad >= 20)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 1:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 30)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 2:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }

                    MechGenerator(10);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 40)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 3:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 50)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 4:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(10);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 60)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 5:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 70)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 6:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(10);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 80)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 7:
                    yield return new WaitForSeconds(3);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 90)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 8:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(10);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 100)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
                case 9:
                    yield return new WaitForSeconds(3);
                    _mechs.Clear();
                    foreach (Transform child in _mechContainer.transform)
                    {
                        if (child.gameObject.activeSelf == false)
                        {
                            Destroy(child.gameObject);
                        }
                    }
                    MechGenerator(4);
                    RequestMech();
                    if (Time.timeSinceLevelLoad >= 110)
                    {
                        _currentWave++;
                        UIManager.Instance.UpdateWaves();
                    }
                    break;
            }
            if (_currentWave >= 10)
            {
                break;
            }
        }
    }
}
