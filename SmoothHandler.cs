using System;
using System.Collections;
using System.Collections.Generic;
namespace Wombat
{

    public class SmoothHandler: GridWrapper<float>
    {
        public readonly float airoffset;



        public SmoothHandler(float[,] data, float airoffset): base(data, -1)
        {
            this.airoffset = airoffset;
        }
        public void Smooth()
        {

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > 4)
                    {
                        if (data[x, y] < airoffset) data[x, y] = airoffset + 0.01f;
                    }
                    else if (neighbourWallTiles < 4)
                    {

                        if (data[x, y] >= airoffset) data[x, y] = airoffset - 0.01f;
                    }

                }
            }
        }

        int GetSurroundingWallCount(int gridX, int gridY)
        {
            int wallCount = 0;
            foreach(GridPair<float> p in Neighbours(gridX, gridY)) {
                wallCount += p.Value < airoffset ? 0 : 1;
                if (wallCount > 4) break;
            }
            return wallCount;
        }
    }
}
