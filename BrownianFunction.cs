using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class BrownianFunction : BaseNoiseFunction
    {

        private readonly INoiseFunction noise;
        private readonly float frequency;
        private readonly int octaves;
        private float persistence = 0.5f;
        private float amplitude = 1;

        public BrownianFunction(INoiseFunction noise, float frequency, int octaves){
            this.noise = noise;
            this.frequency = frequency;
            this.octaves = octaves;
        }

        public BrownianFunction Amplitude(float amplitude)
        {
            this.amplitude = amplitude;
            return this;
        }

        public override float GetNoise(float x, float y, float z)
        {
            float total = 0;
            float maxValue = 0;
            float fr = frequency;
            float ampl = 1;
            for (int i = 0; i < octaves; i++)
            {
                total += noise.GetNoise(x * fr, y * fr, z * fr) * ampl;
                maxValue += ampl;
                ampl *= persistence;
                fr *= 2;
            }
            return (total / maxValue) * amplitude;
    
          //  return noise.FractalBrownian2(x, y);
        }

        public override float GetNoise(float x, float y)
        {
            float total = 0;
            float maxValue = 0;
            float ampl = 1;
            float fr = frequency;
            for (int i = 0; i < octaves; i++)
            {
                total += noise.GetNoise(x * fr, y * fr) * ampl;
                maxValue += ampl;
                ampl *= persistence;
                fr *= 2;
            }
            return (total / maxValue) * amplitude;
        }
    }
}
