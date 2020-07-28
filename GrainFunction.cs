using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wombat
{
    public class GrainFunction : BaseNoiseFunction
    {
        private readonly INoiseFunction noise;
        private float grain;

        public GrainFunction(INoiseFunction noise, float grain)
        {
            this.noise = noise;
            this.grain = grain;
        }

        public override float GetNoise(float x, float y)
        {
            float n = noise.GetNoise(x, y);
            float g = n * grain;
            return (g - (int)g);
        }

        public override float GetNoise(float x, float y, float z)
        {
            float n = noise.GetNoise(x, y, z);
            float g = n * grain;
            return (g - (int)g);
        }
    }
}
