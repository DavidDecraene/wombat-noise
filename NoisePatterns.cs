using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wombat
{
    public class NoisePatterns
    {


        public static BrownianFunction Mountains(NoiseSampler source)
        {
            return new BrownianFunction(source, 0.01f, 5);
        }
    }
}
