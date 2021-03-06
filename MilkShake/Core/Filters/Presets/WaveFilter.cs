﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilkShakeFramework.IO.Input.Devices;

namespace MilkShakeFramework.Core.Filters.Presets
{
    public class WaveFilter : Filter
    {
        public float WaveLength { get; set; }

        public WaveFilter(int waveLength = 200) : base("Scene//Levels//Effects//Wave")
        {
            WaveLength = waveLength;
        }

        public override void FixUp()
        {
            base.FixUp();

            Scene.Listener.Update += new Scenes.UpdateEvent(Update);
        }

        private void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Parameters["wavelength"].SetValue(WaveLength);
        }
    }
}
