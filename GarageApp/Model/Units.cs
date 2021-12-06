using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Model
{
    public class Units
    {
        public int? Id { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int UserID { get; set; }

        public string GetName() => $"Ширина: {Width}, Длина: {Length}, Высота: {Height}";
    }
}
