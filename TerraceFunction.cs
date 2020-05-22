using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class TerraceFunction : INoiseFunction
    {
        private readonly INoiseFunction source;
        private float width = 0.4f;

        public TerraceFunction(INoiseFunction source)
        {
            this.source = source;
        }

        public TerraceFunction Width(float width)
        {
            this.width = width;
            return this;
        }

        public float GetNoise(Vector3 position)
        {
            float v = this.source.GetNoise(position);
            return NoiseSampler.CreateTerraces(v, width);
        }

        public float GetNoise(float x, float y)
        {
            float v = this.source.GetNoise(x, y);
            return NoiseSampler.CreateTerraces(v, width);
        }
    }
}
