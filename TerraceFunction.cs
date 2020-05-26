using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class TerraceFunction : BaseNoiseFunction
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

        public override float GetNoise(float x, float y)
        {
            float v = this.source.GetNoise(x, y);
            return NoiseSampler.CreateTerraces(v, width);
        }

        public override float GetNoise(float x, float y, float z)
        {
            float v = this.source.GetNoise(x, y, z);
            return NoiseSampler.CreateTerraces(v, width);
        }
    }
}
