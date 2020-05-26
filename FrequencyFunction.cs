using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class FrequencyFunction: BaseNoiseFunction
    {
        private readonly INoiseFunction noise;
        private readonly float frequency;
        private float amplitude = 1;

        public FrequencyFunction(INoiseFunction noise, float frequency)
        {
            this.noise = noise;
            this.frequency = frequency;
        }


        public FrequencyFunction Amplitude(float amplitude)
        {
            this.amplitude = amplitude;
            return this;
        }

        public override float GetNoise(float x, float y)
        {
            return noise.GetNoise(x * frequency, y * frequency) * amplitude;
        }

        public override float GetNoise(float x, float y, float z)
        {
            return this.noise.GetNoise(x * frequency, y * frequency, z * frequency) * amplitude;
        }
    }
}
