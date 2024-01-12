using System.Collections;
using TMPro;
using UnityEngine;

namespace KatsisMiniGames.Engine.InterScene
{
    public class InterSceneManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _health;

        private void Awake()
        {
            _health.text = GlobalData.Health.ToString();

            StartCoroutine(WaitAndStart());
        }

        private IEnumerator WaitAndStart()
        {
            yield return new WaitForSeconds(3f);
        }
    }
}