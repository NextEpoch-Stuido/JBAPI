namespace JBAPI.Features.UnityScript
{
    using Exiled.API.Features;
    using System;
    using UnityEngine;

    /// <summary>
    /// 一个TagControlle组件以变换颜色 (其代码作者是NotIntense)
    /// </summary>
    public class TagController : MonoBehaviour
    {
        private Player _player;
        private int _position;
        private string[] _colors;
        private float _timer;

        public string[] Colors
        {
            get => _colors ?? Array.Empty<string>();
            set
            {
                _colors = value ?? Array.Empty<string>();
                _position = 0;
            }
        }

        public float Interval;

        private void Awake()
        {
            _timer = 0;
            _player = Player.Get(gameObject);
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= Interval)
            {
                string text = RollNext();

                if (!string.IsNullOrEmpty(text))
                    _player.RankColor = text;

                _timer = 0;
            }
        }

        private string RollNext()
        {
            if (_colors.Length == 0)
                return string.Empty;

            _position = (_position + 1) % _colors.Length;
            return _colors[_position];
        }
    }
}