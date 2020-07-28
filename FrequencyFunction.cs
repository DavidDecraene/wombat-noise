using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class FrequencyFunction: BaseNoiseFunction
    {
        private readonly INoiseFunction noise;
        private readonly Vector3 frequency;
        private float amplitude = 1;

        public FrequencyFunction(INoiseFunction noise, float frequency)
        {
            this.noise = noise;
            this.frequency = new Vector3(frequency, frequency, frequency);
        }

        public FrequencyFunction(INoiseFunction noise, Vector3 frequency)
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
            return noise.GetNoise(x * GetFreq(frequency.x), y * GetFreq(frequency.y)) * amplitude;
        }

        private float GetFreq(float v)
        {
            if (v <= 0) return 1;
            return v;
        }

        public override float GetNoise(float x, float y, float z)
        {
            return this.noise.GetNoise(x * GetFreq(frequency.x) , y * GetFreq(frequency.y), z * GetFreq(frequency.z)) * amplitude;
        }
    }
}
