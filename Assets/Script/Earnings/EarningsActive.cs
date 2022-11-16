using UnityEngine.EventSystems;

namespace IncomeResourse
{
    public class EarningsActive : Earnings, IPointerClickHandler
    {
        public static event OnActivIncome ActivIncome;
        public delegate void OnActivIncome(int pactivIncome);

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            _resourseText.gameObject.SetActive(true);
            StartCoroutine("NoActivText");
            ActivIncome(_resource);
            _resourseText.text = "+" + _resource.ToString();
        }
    }
}
