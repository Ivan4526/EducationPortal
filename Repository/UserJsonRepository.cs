using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class UserJsonRepository<T> : IRepository<T> where T : class
    {
        readonly string path = @"D:\json\Info.json";
        List<T> entities = new List<T>();
        public UserJsonRepository()
        {
            //var logfile = File.ReadAllLines(path);
            entities = new List<T>();
            var jsonData = File.ReadAllLines(path);
            foreach(var json in jsonData)
            {
                entities.Add(JsonConvert.DeserializeObject<T>(json));
            }
        }
        public void Create(T entity)
        {
            string jsonResult = JsonConvert.SerializeObject(entity);
            using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
               using(var sw = new StreamWriter(stream))
                {
                    sw.WriteLine(jsonResult);
                }
            }
        }
        public IEnumerable<T> ReadAll()
        {
            return entities;
        }
        public T Read(Expression<Func<T, bool>> predicate)
        {
            return entities.FirstOrDefault(predicate.Compile());
        }
        public void Update(T user)
        {

        }
        public void Delete(T user)
        {

        }
    }
}
