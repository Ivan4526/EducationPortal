using Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JsonRepository<T> : IRepository<T> where T : BaseEntity
    {
        readonly string path;
        List<T> entities = new List<T>();
        public JsonRepository(string path)
        {
            this.path = path;
            entities = new List<T>();
            var jsonData = File.ReadAllLines(path);
            foreach (var json in jsonData)
            {
                entities.Add(JsonConvert.DeserializeObject<T>(json));
            }
        }
        public async Task Create(T entity)
        {
            string jsonResult = JsonConvert.SerializeObject(entity);
            using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                using (var sw = new StreamWriter(stream))
                {
                    sw.WriteLine(jsonResult);
                }
            }
        }
        public async Task<IEnumerable<T>> ReadAll()
        {
            return entities;
        }
        public async Task<IEnumerable<T>> ReadAll(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate.Compile());
        }
        public async Task<T> Read(Expression<Func<T, bool>> predicate)
        {
            return entities.FirstOrDefault(predicate.Compile());
        }
        public async Task<T> Read(int id)
        {
            return entities.FirstOrDefault(x => x.Id == id);
        }
        public async Task Update(T user)
        {

        }
        public async Task Delete(int id)
        {

        }
    }
}
