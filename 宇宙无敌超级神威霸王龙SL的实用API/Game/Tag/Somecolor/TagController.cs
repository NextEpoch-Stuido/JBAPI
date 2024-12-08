using System.Collections;
using UnityEngine;
using Exiled.API.Features;
using System;

namespace JBAPI.UnityScript
{
    public class TagController : MonoBehaviour
    {
        private Player player;
        private int positionIndex = 0;
        private string[] colors = Array.Empty<string>();
        private float timer = 0f;

        public string[] Colors
        {
            get => colors;
            set
            {
                colors = value ?? Array.Empty<string>();
                positionIndex = 0;
            }
        }

        public float Interval { get; set; }

        void Awake()
        {
            player = Player.Get(gameObject);

            if (player == null)
            {
                Destroy(this);
                return;
            }

            StartCoroutine(InitializeColorChange());
        }

        IEnumerator InitializeColorChange()
        {
            yield return new WaitForSeconds(0.5f);

            SetNextColor();
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer >= Interval)
            {
                SetNextColor();
                timer %= Interval;
            }
        }

        void SetNextColor()
        {
            var nextColor = RollNext();
            if (!string.IsNullOrEmpty(nextColor))
                player.RankColor = nextColor;
        }

        public string RollNext()
        {
            if (colors.Length == 0)
                return string.Empty;

            positionIndex++;
            if (positionIndex >= colors.Length) positionIndex = 0;

            return colors[positionIndex];
        }
    }
}
