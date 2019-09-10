using NET.A._2019.Gridushko._15.BLL.Interface.Interfaces;
using System;

namespace NET.A._2019.Gridushko._15
{
    public class Generator : IGenerator
    {

        private int id;
        public Generator()
        {
            this.Id = 0;
        }
        public Generator(int id)
        {
            this.Id = id;
        }
        private int Id
        {
            get => this.id;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("No -Id", nameof(value));
                }

                this.id = value;
            }
        }
        public int GenerateId()
        {
            return Id++;
        }
    }
}