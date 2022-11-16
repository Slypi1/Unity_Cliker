using System.Collections;
using UnityEngine;
using TMPro;

namespace IncomeResourse
{
    public class Earnings : MonoBehaviour
    {
        public int _resource;
        public float _timerLiveText;
        public TMP_Text _resourseText;

        public IEnumerator NoActivText()
        {
            yield return new WaitForSeconds(_timerLiveText);
            _resourseText.gameObject.SetActive(false);
        }
    }
}
