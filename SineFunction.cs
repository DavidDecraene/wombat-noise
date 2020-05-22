using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class SineFunction: INoiseFunction
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

        public float GetNoise(float x, float y)
        {

            if (radial)
            {
                return noise.RadialSineWave2(x, y, frequencyX, frequencyY, amplitude);
            }
            return noise.SineWave2(x, y, frequencyX, frequencyY, amplitude);
        }

        public float GetNoise(Vector3 position)
        {
            if (radial)
            {
                return noise.RadialSineWave2(position, frequencyX, frequencyY, amplitude);
            }
            return noise.SineWave2(position, frequencyX, frequencyY, amplitude);
        }
    }
}
