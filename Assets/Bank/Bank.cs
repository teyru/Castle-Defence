using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Bank : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayBalance;
    [SerializeField] private int _startBalance = 150;

    [SerializeField] private int _currentBalance;



    public int CurrentBalance {get { return _currentBalance; } }



    void Awake()
    {
        _currentBalance = _startBalance;
        UpdateBalance();
    }

    public void Deposit(int amount)
    {
        _currentBalance += Mathf.Abs(amount);
        UpdateBalance();
    }

    public void Withdraw(int amount)
    {
        _currentBalance -= Mathf.Abs(amount);
        UpdateBalance();
        if (_currentBalance < 0)
        {
            ReloadLevel();
        }
    }

    private void UpdateBalance()
    {
        _displayBalance.text = "Gold: " + _currentBalance;
    }


    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


}
