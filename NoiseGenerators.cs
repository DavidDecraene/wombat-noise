using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class NoiseGenerators
    {


        public static TerraceFunction Terrace(INoiseFunction basis)
        {
            return new TerraceFunction(basis);
        }

        public static AbsoluteFunction Absolute(INoiseFunction basis)
        {
            return new AbsoluteFunction(basis);
        }

        public static FrequencyFunction Frequency(NoiseSampler source, float frequency)
        {
            return new FrequencyFunction(source, frequency);
        }

        public static FrequencyFunction SandDunes(NoiseSampler source)
        {
            return new FrequencyFunction(source, 0.01f).Amplitude(50);
        }
    }
}
