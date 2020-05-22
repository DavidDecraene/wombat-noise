using System.Collections;
using System.Collections.Generic;
using System;
namespace Wombat
{
    [Flags]
    public enum GridCellNeighbour
    {
        NONE = 0,
        TOPLEFT = 1 << 0,
        TOP = 1 << 1,
        TOPRIGHT = 1 << 2,
        LEFT = 1 << 3,
        RIGHT = 1 << 4,
        BOTLEFT = 1 << 5,
        BOT = 1 << 6,
        BOTRIGHT = 1 << 7,
        DIAGONAL = TOPLEFT | TOPRIGHT | BOTLEFT | BOTRIGHT,
        ADJACENT = TOP | BOT | LEFT | RIGHT
    }
}
