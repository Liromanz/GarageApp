using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Model
{
    internal class CalculateUnit
    {
        public int id;
        public int width;
        public int height;
        public int startX;
        public int startY;
        public int endX => startX + width;
        public int endY => startY + height;
    }
}
