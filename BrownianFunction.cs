using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class BrownianFunction : INoiseFunction
    {

        private readonly NoiseSampler noise;
        private readonly float frequency;
        private readonly int octaves;
        private float persistence = 0.5f;
        private float amplitude = 1;

        public BrownianFunction(NoiseSampler noise, float frequency, int octaves){
            this.noise = noise;
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public BrownianFunction Amplitude(float amplitude)
        {
            this.amplitude = amplitude;
            return this;
        }

        public float GetNoise(Vector3 position)
        {
            return this.noise.FractalBrownian2(position, octaves, persistence, frequency, 1) * amplitude;

        }

        public float GetNoise(float x, float y)
        {
            return this.noise.FractalBrownian2(x, y, octaves, persistence, frequency, 1) * amplitude;
        }
    }
}
