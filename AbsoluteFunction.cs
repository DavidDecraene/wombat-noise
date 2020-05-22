using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class AbsoluteFunction: INoiseFunction
    {

        private readonly INoiseFunction source;
        private bool inverted = false;

        public AbsoluteFunction(INoiseFunction source)
        {
            this.source = source;
        }

        public AbsoluteFunction Invert()
        {
            this.inverted = true;
            return this;
        }

        public float GetNoise(float x, float y)
        {
            float v = Mathf.Abs(this.source.GetNoise(x, y));
            if (inverted) v *= -1;
            return v;
        }

        public float GetNoise(Vector3 position)
        {
            float v = Mathf.Abs(this.source.GetNoise(position));
            if (inverted) v *= -1;
            return v;
        }
    }
}
