using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    /**
     *  function warp(sampler, source, freq, v2, v1) {
    if (!v1) v1 = new Vector2(0, 0);
    if (!v2) v2 = new Vector2(5.2, 1.3);
    const q1 = sampler.getNoise((source.x + v1.x) * freq, (source.y + v1.y) * freq);
    const q2 = sampler.getNoise(( source.x + v2.x) * freq, ( source.y + v2.y) * freq);
    return sampler.getNoise((source.x + wScale * q1) * freq, (source.y + wScale * q2) * freq);
  }
        

  function warpVector(sampler, source, freq, v2, v1) {
    if (!v1) v1 = new Vector2(0, 0);
    if (!v2) v2 = new Vector2(5.2, 1.3);
    const q1 = sampler.getNoise((source.x + v1.x) * freq, (source.y + v1.y) * freq);
    const q2 = sampler.getNoise(( source.x + v2.x) * freq, ( source.y + v2.y) * freq);
    return new Vector2((source.x + wScale * q1) * freq , (source.y + wScale * q2) * freq);
  }

  function dualWarp(sampler, source, freq) {
    const s1 = warpVector(sampler, source, freq);
    const source2 = source.add(s1.mult(wScale));
    const s2 = warpVector(sampler, source2, freq, new Vector2(8.3,2.8), new Vector2(1.7,9.2));
    const result = s1.add(s2.mult(wScale));
    return sampler.getNoise(result.x * freq , result.y* freq);
  }
     * */
    public class DomainWarpFunction : BaseNoiseFunction
    {
        public Vector3 offset1;
        public Vector3 offset2 = new Vector3(5.2f, 0, 1.3f);
        public Vector3 offset3;
        public float frequency = 1f;
        public float amplitude = 1f;
        private readonly INoiseFunction source;
        public bool useDualWarp = false;

        public DomainWarpFunction(INoiseFunction source)
        {
            this.source = source;

        }

        public float DualWarp(Vector2 source)
        {
            Vector2 s1 = WarpVector(source, offset1, offset2);
            Vector2 source2  = source + s1 * amplitude;
            Vector2 s2 = WarpVector(source2, new Vector2(8.3f, 2.8f), new Vector2(1.7f, 9.2f));
            Vector2 result = s1 + s2 * amplitude;
            return this.source.GetNoise(result.x * frequency, result.y * frequency);
        }

        public Vector2 WarpVector(Vector2 input, Vector3 offset1, Vector3 offset2)
        {
            float q1 = source.GetNoise((input.x + offset1.x) * frequency, (input.y + offset1.z) * frequency);
            float q2 = source.GetNoise((input.x + offset2.x) * frequency, (input.y + offset2.z) * frequency);
            return new Vector2((input.x + q1 * amplitude) * frequency, (input.y + q2 * amplitude) * frequency);
        }

        public override float GetNoise(float x, float y)
        {
            if (useDualWarp)
            {
                return DualWarp(new Vector2(x, y));
            }
            float q1 = source.GetNoise((x + offset1.x) * frequency, (y + offset1.z) * frequency);
            float q2 = source.GetNoise((x + offset2.x) * frequency, (y + offset2.z) * frequency);
            return source.GetNoise((x + q1 * amplitude) * frequency, (y + q2 * amplitude) * frequency);
        }

        public Vector3 WarpVector(float x, float y, float z)
        {
            float q1 = source.GetNoise((x + offset1.x) * frequency, (y + offset1.y) * frequency, (z + offset1.z) * frequency);
            float q2 = source.GetNoise((x + offset2.x) * frequency, (y + offset2.y) * frequency, (z + offset2.z) * frequency);
            float q3 = source.GetNoise((x + offset3.x) * frequency, (y + offset3.y) * frequency, (z + offset3.z) * frequency);
            return new Vector3((x + q1 * amplitude) * frequency, (y + q2 * amplitude) * frequency, (z + q3 * amplitude) * frequency);
        }

        public override float GetNoise(float x, float y, float z)
        {
            float q1 = source.GetNoise((x + offset1.x) * frequency, (y + offset1.y) * frequency, (z + offset1.z) * frequency);
            float q2 = source.GetNoise((x + offset2.x) * frequency, (y + offset2.y) * frequency, (z + offset2.z) * frequency);
            float q3 = source.GetNoise((x + offset3.x) * frequency, (y + offset3.y) * frequency, (z + offset3.z) * frequency);
            return source.GetNoise((x + q1 * amplitude) * frequency, (y + q2 * amplitude) * frequency, (z + q3 * amplitude) * frequency);
        }
    }
}
