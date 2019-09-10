namespace Task._8._1.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;

    using Task._8._1.Repositories.Interfaces;

    public class FileRepository<T> : IRepository<T> where T : new()
    {
        private const string FileName = "FileRepository.bin";

        private readonly BinaryFormatter formatter = new BinaryFormatter();

        public void Add(T obj)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new Exception("Can't add not serializable object");
            }

            var fileData = this.ReadFile();

            if (fileData != null)
            {
                fileData.Add(obj);
            }
            else
            {
                fileData = new List<object> { obj };
            }

            this.WriteFile(fileData);
        }

        public void Remove(T obj)
        {
            var fileData = this.ReadFile();

            if (fileData == null)
            {
                return;
            }

            fileData.Remove(obj);

            this.WriteFile(fileData);
        }

        public List<T> GetAll()
        {
            return this.ReadFile().OfType<T>().ToList();
        }

        private List<object> ReadFile()
        {
            if (!File.Exists(FileName))
            {
                return null;
            }

            List<object> result;

            using (var fileStream = File.Open(FileName, FileMode.Open, FileAccess.Read))
            {
                result = this.formatter.Deserialize(fileStream) as List<object>;
            }

            return result;
        }

        private void WriteFile(List<object> obj)
        {
            using (var fileStream = File.Open(FileName, FileMode.Create, FileAccess.Write))
            {
                this.formatter.Serialize(fileStream, obj);
            }
        }

    }
}
