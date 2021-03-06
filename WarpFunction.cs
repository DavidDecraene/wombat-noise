﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class WarpFunction : INoiseFunction
    {

        private readonly INoiseFunction source;
        private float amplitude = 8f;
        private float frequency = 0.04f;
        private readonly FastNoise noise;

        public WarpFunction(INoiseFunction source, FastNoise noise)
        {
            this.noise = noise;
            this.source = source;

        }

        public WarpFunction Frequency(float frequency)
        {
            this.frequency = frequency;
            return this;
        }

        public WarpFunction Amplitude(float ampl)
        {
            this.amplitude = ampl;
            return this;
        }

        public float GetNoise(Vector3 position)
        {
            float x = position.x;
            float y = position.y;
            float z = position.z;
            noise.GradientPerturb(ref x, ref y, ref z);
            return this.source.GetNoise(new Vector3(x, y, z));
        }

        public float GetNoise(float x, float y)
        {
            float xx = x;
            float yy = y;
            noise.GradientPerturb(ref xx, ref yy);
            return this.source.GetNoise(xx, yy);
        }

        public float GetNoise(float x, float y, float z)
        {
            /**
             * 
            float v = this.source.GetNoise(x * frequency, y * frequency, z * frequency) * amplitude;
            return this.source.GetNoise(x + v, y + v, z + v);
             */
            float xx = x;
            float yy = y;
            float zz = z;
            noise.GradientPerturb(ref xx, ref yy, ref zz);
            return this.source.GetNoise(xx, yy, zz);
        }
    }
}
