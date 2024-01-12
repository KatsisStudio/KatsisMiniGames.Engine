using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KatsisMiniGames.Engine.Game
{
    public class VictoryManager : MonoBehaviour
    {
        public static VictoryManager Instance { private set; get; }

        [SerializeField]
        private GameObject _victory;

        [SerializeField]
        private TMP_Text _timerText;

        private float _timer = 10f;

        public bool DidGameEnd { private set; get; }

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (!DidGameEnd)
            {
                _timer -= Time.deltaTime;
                _timerText.text = Mathf.CeilToInt(_timer).ToString();

                if (_timer <= 0f)
                {
                    Loose();
                }
            }
        }

        public void Win()
        {
            if (!DidGameEnd)
            {
                StartCoroutine(EndGame());
            }
        }

        private void Loose()
        {
            GlobalData.Health--;
            StartCoroutine(EndGame());
        }

        private IEnumerator EndGame()
        {
            DidGameEnd = true;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("InterScene");
        }
    }
}
