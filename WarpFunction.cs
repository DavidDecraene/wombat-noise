using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class WarpFunction : INoiseFunction
    {

        private readonly INoiseFunction source;
        private float amplitude = 8f;
        private float frequency = 0.04f;

        public WarpFunction(INoiseFunction source)
        {
            this.source = source;

        }

        public WarpFunction Frequency(float frequency)
        {
            this.amplitude = frequency;
            return this;
        }

        public WarpFunction Amplitude(float ampl)
        {
            this.amplitude = ampl;
            return this;
        }

        public float GetNoise(Vector3 position)
        {
            float v = this.source.GetNoise(position * frequency) * amplitude;
            return this.source.GetNoise(new Vector3(position.x + v, position.y + v, position.z + v));

        }

        public float GetNoise(float x, float y)
        {
            float v = this.source.GetNoise(x * frequency, y * frequency) * amplitude;
            return this.source.GetNoise(x + v, y + v);
        }
    }
}
