using System;
namespace NET.A._2019.Gridushko._22
{
    /// <summary>
    /// Generate id.
    /// </summary>
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
                this.id = value;
            }
        }

        /// <summary>
        /// Creates new id by incrementing it.
        /// </summary>
        public int GenerateId()
        {
            return Id++;
        }
    }
}