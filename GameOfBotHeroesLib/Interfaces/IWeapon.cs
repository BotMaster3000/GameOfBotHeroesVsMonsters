﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfBotLib.Interfaces
{
    public interface IWeapon : IItem
    {
        int Attack { get; }
    }
}
