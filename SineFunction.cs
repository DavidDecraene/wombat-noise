using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class SineFunction: BaseNoiseFunction
    {
        private readonly NoiseSampler noise;
        private readonly float frequencyX, frequencyY;
        private float amplitude = 1;
        private bool radial = true;

        public SineFunction(NoiseSampler noise, float frequencyX, float frequencyY)
        {
            this.noise = noise;
            this.frequencyX = frequencyX;
            this.frequencyY = frequencyY;
        }

        public SineFunction Amplitude(float amplitude)
        {
            this.amplitude = amplitude;
            return this;
        }

        public SineFunction Radial(bool radial)
        {
            this.radial = radial;
            return this;
        }

        public SineFunction Plain()
        {
            this.radial = false;
            return this;
        }

        public override float GetNoise(float x, float y)
        {

            float n = this.noise.GetNoise(x, y);
            if (radial)
            {
                n = NoiseSampler.ShiftInterval(-1, 1, Mathf.PI, 0, n);
            }
            return Mathf.Cos(n * amplitude);
        }

        public override float GetNoise(float x, float y, float z)
        {
            float n = GetNoise(x, y, z);
            if (radial)
            {
                n = NoiseSampler.ShiftInterval(-1, 1, Mathf.PI, 0, n);
            }
            return Mathf.Cos(n * amplitude);
        }
    }
}
