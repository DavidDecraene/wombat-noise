using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public interface INoiseFunction {
        float GetNoise(Vector3 position);
        float GetNoise(float x, float y);
        float GetNoise(float x, float y, float z);
    }

    public abstract class BaseNoiseFunction: INoiseFunction
    {
        public abstract float GetNoise(float x, float y);
        public abstract float GetNoise(float x, float y, float z);

        public float GetNoise(Vector3 position)
        {
            return GetNoise(position.x, position.y, position.z);
        }

        public float GetNoise(Vector2 position)
        {
            return GetNoise(position.x, position.y);
        }

    }



    public class NoiseSampler: INoiseFunction
    {
        private readonly FastNoise noise;

        /**
         * terraceWidth for example 0.4
         */
        public static float CreateTerraces(float height, float terraceWidth)
        {
            float k = Mathf.Floor(height / terraceWidth);
            var f = (height - k * terraceWidth) / terraceWidth;
            var s = Mathf.Min(2 * f, 1.0f);
            return (k + s) * terraceWidth;
        }

        public static float ShiftInterval(float from, float to, float newFrom, float newTo, float value)
        {
            float dc = newTo - newFrom;
            float ba = to - from;
            return ((value - from) * dc / ba) + newFrom;
        }

        public NoiseSampler(FastNoise noise)
        {
            this.noise = noise;
            this.noise.SetFrequency(1);
        }

        public float GetNoise2(float x, float y, float frequency)
        {
            return this.noise.GetNoise(x * frequency, y * frequency);
        }

        public float GetNoise2(Vector3 position, float frequency)
        {
            return this.noise.GetNoise(position.x * frequency, position.y * frequency);
        }

        public float GetNoise2(Vector3 position, float frequencyX, float frequencyY)
        {
            return this.noise.GetNoise(position.x * frequencyX, position.y * frequencyY);
        }

        public float GetNoise3(Vector3 position, float frequency)
        {
            return this.noise.GetNoise(position.x * frequency, position.y * frequency, position.z * frequency);
        }

        public float GetNoise3(float x, float y, float z, float frequency)
        {
            return this.noise.GetNoise(x * frequency, y * frequency, z * frequency);
        }


        public float GetNoise(float x, float y)
        {
            return this.noise.GetNoise(x, y);
        }

        public float GetNoise(float x, float y, float z)
        {
            return this.noise.GetNoise(x, y, z);
        }


        public float GetNoise(Vector3 position)
        {
            return this.noise.GetNoise(position.x, position.y, position.z);
        } 
        public float FractalBrownian2(float x, float y, int octaves, float persistence, float frequency, float amplitude)
        {
            float total = 0;
            float maxValue = 0;
            for (int i = 0; i < octaves; i++)
            {
                total += GetNoise2(x, y, frequency) * amplitude;
                maxValue += amplitude;
                amplitude *= persistence;
                frequency *= 2;
            }
            return total / maxValue;
        }

        public float FractalBrownian3(float x, float y, float z, int octaves, float persistence, float frequency, float amplitude)
        {
            float total = 0;
            float maxValue = 0;
            for (int i = 0; i < octaves; i++)
            {
                total += GetNoise3(x, y, z, frequency) * amplitude;
                maxValue += amplitude;
                amplitude *= persistence;
                frequency *= 2;
            }
            return total / maxValue;
        }

        public float FractalBrownian2(Vector3 position, int octaves, float persistence, float frequency, float amplitude)
        {
            float total = 0;
            float maxValue = 0;
            for (int i = 0; i < octaves; i++)
            {
                total += GetNoise2(position, frequency) * amplitude;
                maxValue += amplitude;
                amplitude *= persistence;
                frequency *= 2;
            }
            return total / maxValue;
        }

        public float SineWave2(Vector3 position, float frequencyX, float frequencyY, float amplitude)
        {
            return Mathf.Cos(GetNoise2(position, frequencyX, frequencyY) * amplitude);
        }

        public float RadialSineWave2(Vector3 position, float frequencyX, float frequencyY, float amplitude)
        {
            float noise = GetNoise2(position, frequencyX, frequencyY);
            noise = ShiftInterval(-1, 1, Mathf.PI, 0, noise);
            return Mathf.Cos(noise * amplitude);
        }

        public float RadialSineWave(float x, float y, float z, float amplitude)
        {
            float noise = GetNoise(x, y, z );
            noise = ShiftInterval(-1, 1, Mathf.PI, 0, noise);
            return Mathf.Cos(noise * amplitude);
        }

        public float SineWave(float x, float y, float z, float amplitude)
        {
            float noise = this.noise.GetNoise(x, y, z);
            return Mathf.Cos(noise * amplitude);
        }

        public float SineWave2(float x, float y, float frequencyX, float frequencyY, float amplitude)
        {
            float noise = this.noise.GetNoise(x * frequencyX, y * frequencyY);
            return Mathf.Cos(noise * amplitude);
        }

        public float RadialSineWave2(float x, float y, float frequencyX, float frequencyY, float amplitude)
        {
            float noise = this.noise.GetNoise(x * frequencyX, y * frequencyY);
            noise = ShiftInterval(-1, 1, Mathf.PI, 0, noise);
            return Mathf.Cos(noise * amplitude);
        }


    }
}
