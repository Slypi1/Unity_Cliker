using System.Collections;
using UnityEngine;

namespace IncomeResourse
{
    public class EarningsPassive : Earnings
    {
        [SerializeField] private float _timerEarningsPassive;

        public static event OnPassiveIncome PassiveIncome;
        public delegate void OnPassiveIncome(int passiveIncome);

        private void Awake()
        {
            EarningsPassiveRepeat();
        }

        private void EarningsPassiveRepeat()
        {
            StartCoroutine("IncomePassive");
        }

        private IEnumerator IncomePassive()
        {
            yield return new WaitForSeconds(_timerEarningsPassive);
            ActivText();
            EarningsPassiveRepeat();
        }

        private void ActivText()
        {
            _resourseText.gameObject.SetActive(true);
            _resourseText.text = "+" + _resource.ToString();
            StartCoroutine("NoActivText");
            PassiveIncome(_resource);
        }
    }
}
