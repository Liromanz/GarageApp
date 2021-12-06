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
        public float Width { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public float Lenght { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public int User_ID { get; set; }
    }
}
