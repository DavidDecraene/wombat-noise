using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wombat
{
    public readonly struct GridPair<DataType>
    {
        public GridPair(GridCellNeighbour type, DataType value)
        {
            Type = type;
            Value = value;
        }

        public GridCellNeighbour Type { get; }
        public DataType Value { get; }
    }

    public class GridReference<Type>
    {
        public readonly GridWrapper<Type> model;
        public readonly int x;
        public readonly int y;

        public GridReference(int x, int y, GridWrapper<Type> model)
        {
            this.x = x;
            this.y = y;
            this.model = model;
        }

        public bool TopLeft(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.TOPLEFT, out result);
        }

        public bool Top(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.TOP, out result);
        }

        public bool TopRight(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.TOPRIGHT, out result);
        }

        public bool Left(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.LEFT, out result);
        }

        public bool Right(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.RIGHT, out result);
        }

        public bool BotLeft(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.BOTLEFT, out result);
        }

        public bool Bot(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.BOT, out result);
        }

        public bool BotRight(out Type result)
        {
            return model.TryGetValue(x, y, GridCellNeighbour.BOTRIGHT, out result);
        }

        public IEnumerable<GridPair<Type>> Neighbours(bool includeDiagonals)
        {
            return model.Neighbours(x, y, includeDiagonals);
        }

    }

    public class GridWrapper<Type>
    {
        public readonly Type[,] data;
        public readonly int width;
        public readonly int height;
        private readonly Type nullValue = default;

        public GridWrapper(Type[,] data, Type nullValue)
        {
            this.data = data;
            width = data.GetLength(0);
            height = data.GetLength(1);
        }

        public bool TryGetValue(int x, int y, out Type result)
        {
            if (x < 0 || y < 0)
            {
                result = nullValue;
                return false;
            }
            if (x >= width || y >= height)
            {

                result = nullValue;
                return false;
            }
            result = data[x, y];
            return true;
        }

        public bool TryGetValue(int x, int y, GridCellNeighbour n,  out Type result)
        {
            switch (n)
            {
                case GridCellNeighbour.TOPLEFT:
                    return TryGetValue(x - 1, y - 1, out result);
                case GridCellNeighbour.TOP:
                    return TryGetValue(x , y - 1, out result);
                case GridCellNeighbour.TOPRIGHT:
                    return TryGetValue(x + 1, y - 1, out result);
                case GridCellNeighbour.LEFT:
                    return TryGetValue(x - 1, y, out result);
                case GridCellNeighbour.RIGHT:
                    return TryGetValue(x + 1, y, out result);
                case GridCellNeighbour.BOTLEFT:
                    return TryGetValue(x - 1, y + 1, out result);
                case GridCellNeighbour.BOT:
                    return TryGetValue(x, y + 1, out result);
                case GridCellNeighbour.BOTRIGHT:
                    return TryGetValue(x + 1, y + 1, out result);
            }
            result = nullValue;
            return false;
        }

        public IEnumerable<GridPair<Type>> Neighbours(int x, int y)
        {
            return Neighbours(x, y, true);
        }


        public IEnumerable<GridPair<Type>> Neighbours(int x, int y, bool includeDiagonals)
        {
            // Type result;
            if(includeDiagonals && TryGetValue(x, y, GridCellNeighbour.TOPLEFT, out Type result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.TOPLEFT, result);
            }
            if (TryGetValue(x, y , GridCellNeighbour.TOP, out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.TOP, result);
            }
            if (includeDiagonals && TryGetValue(x , y , GridCellNeighbour.TOPRIGHT, out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.TOPRIGHT, result);
            }
            if (TryGetValue(x , y, GridCellNeighbour.LEFT, out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.LEFT, result);
            }
            if (TryGetValue(x , y, GridCellNeighbour.RIGHT, out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.RIGHT, result);
            }
            if (includeDiagonals && TryGetValue(x , y, GridCellNeighbour.BOTLEFT, out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.BOTLEFT, result);
            }
            if (TryGetValue(x, y, GridCellNeighbour.BOT,  out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.BOT, result);
            }
            if (includeDiagonals && TryGetValue(x, y, GridCellNeighbour.BOTRIGHT, out result))
            {
                yield return new GridPair<Type>(GridCellNeighbour.BOTRIGHT, result);
            }
        }

    }
}
