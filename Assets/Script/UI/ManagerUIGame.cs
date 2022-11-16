using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using IncomeResourse;

public class ManagerUIGame : MonoBehaviour
{
    [SerializeField] private TMP_Text _allEarningsText;
    private int _allEarnings;

    void OnEnable()
    {
        EarningsPassive.PassiveIncome += IncomePassive;
        EarningsActive.ActivIncome += IncomeActiv;
    }

    void OnDisable()
    {
        EarningsPassive.PassiveIncome -= IncomePassive;
        EarningsActive.ActivIncome -= IncomeActiv;
    }

    private void IncomePassive(int incomePassive)
    {
      
         IncomePrint(incomePassive);
    }

    private void IncomeActiv(int incomeActive)
    {
        IncomePrint(incomeActive);
    }

    private void IncomePrint(int income)
    {
        _allEarnings += income;
        _allEarningsText.text = _allEarnings.ToString();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
