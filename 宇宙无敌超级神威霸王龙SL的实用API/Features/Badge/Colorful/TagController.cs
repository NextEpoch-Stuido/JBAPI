// -----------------------------------------------------------------------
// <copyright file="TagController.cs" company="JBAPI-Team">
// Copyright (c) JBAPI-Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace JBAPI.Features.UnityScript
{
    using System;
    using Exiled.API.Features;
    using UnityEngine;

    /// <summary>
    /// Represents a tag controller component that changes tag color at intervals.
    /// </summary>
    /// <remarks>
    /// Original code by NotIntense.
    /// </remarks>
    public class TagController : MonoBehaviour
    {
        /// <summary>
        /// The player associated with this tag controller.
        /// </summary>
        private Player player;

        /// <summary>
        /// The current position in the color array.
        /// </summary>
        private int position;

        /// <summary>
        /// The array of colors to cycle through.
        /// </summary>
        private string[] colors;

        /// <summary>
        /// Timer to track time intervals for changing colors.
        /// </summary>
        private float timer;

        /// <summary>
        /// Gets or sets the colors to cycle through.
        /// </summary>
        public string[] Colors
        {
            get => this.colors ?? Array.Empty<string>();
            set
            {
                this.colors = value ?? Array.Empty<string>();
                this.position = 0;
            }
        }

        /// <summary>
        /// Gets or sets the time interval for changing colors.
        /// </summary>
        public float Interval { get; set; }

        /// <summary>
        /// Unity's Awake method, called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            this.timer = 0;
            this.player = Player.Get(this.gameObject);
        }

        /// <summary>
        /// Unity's Update method, called once per frame.
        /// </summary>
        private void Update()
        {
            this.timer += Time.deltaTime;

            if (this.timer >= this.Interval)
            {
                string nextColor = this.RollNext();

                if (!string.IsNullOrEmpty(nextColor))
                {
                    this.player.RankColor = nextColor;
                }

                this.timer = 0;
            }
        }

        /// <summary>
        /// Rolls to the next color in the array.
        /// </summary>
        /// <returns>The next color as a string, or an empty string if no colors are available.</returns>
        private string RollNext()
        {
            if (this.colors.Length == 0)
            {
                return string.Empty;
            }

            this.position = (this.position + 1) % this.colors.Length;
            return this.colors[this.position];
        }
    }
}
