using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class FrequencyFunction: INoiseFunction
    {
        private readonly NoiseSampler noise;
        private readonly float frequency;
        private float amplitude = 1;
        private readonly bool d2 = true;

        public FrequencyFunction(NoiseSampler noise, float frequency)
        {
            this.noise = noise;
            this.frequency = frequency;
        }

        public FrequencyFunction Amplitude(float amplitude)
        {
            this.amplitude = amplitude;
            return this;
        }

        public float GetNoise(float x, float y)
        {
            float result = noise.GetNoise2(x, y, frequency) * amplitude;
            return result;
        }

        public float GetNoise(Vector3 position)
        {
            return d2 ? this.noise.GetNoise2(position, frequency) * amplitude
                 : this.noise.GetNoise3(position, frequency) * amplitude;
        }
    }
}
