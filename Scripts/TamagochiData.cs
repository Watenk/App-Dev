using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Dev_VisalStudio
{
    public class TamagochiData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Hunger { get; set; }
        public float Thirst {  get; set; }
        public float Boredom { get; set; }
        public float Loneliness { get; set; }
        public float Stimulated { get; set; }
        public float Fatigue { get; set; }

        public TamagochiData()
        {
            Id = 0;
            Name = "Poekie";
            Hunger = 0;
            Thirst = 0;
            Boredom = 0;
            Loneliness = 0;
            Stimulated = 0;
            Fatigue = 0;
        }
    }
}
