using PKUMonitor.Entidades;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace PKUMonitor
{
   public class Repositorio<T> where T:BaseDTO
    {
        MongoClient client;
        IMongoDatabase db;
        bool resultado;

        public string Error { get; private set; }

        public Repositorio()
        {
            client = new MongoClient(@"Insira o link de conexão do mongodb");
            db = client.GetDatabase("pkumonitor");
        }
        private IMongoCollection<T> Collection() => db.GetCollection<T>(typeof(T).Name);
        public  T Create(T entidad)
        {
            entidad.Id = ObjectId.GenerateNewId().ToString();
            entidad.FechaHora = DateTime.Now;
            try
            {
                Collection().InsertOne(entidad);
                Error = "";
                resultado = true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                resultado = false;
 
            }
            return resultado ? entidad : null;
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read
        {
            get
            {
                try
                {
                    Error = "";
                    return Collection().AsQueryable();

                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    return null;
                }
                
            }
        }

        public T Update(T entidad)
        {
            entidad.FechaHora = DateTime.Now;
            try
            {
                int r = (int)Collection().ReplaceOne(e => e.Id == entidad.Id, entidad).ModifiedCount;
                Error = r == 1 ? "Elemento modificado" : "Não tem elemento modificado";
                resultado = r == 1;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                resultado = false;
            }
            return resultado ? entidad : null;
        }

        public bool Delete(T entidad)
        {
            try
            {
                int r = (int)Collection().DeleteOne(e => e.Id == entidad.Id).DeletedCount;
                resultado = r == 1;
                Error = resultado ? "Elemento excluido" : "Não pode eliminar o elemento";
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                resultado = false;
            }
            return resultado;
        }
        public T SearchById(string id)
        {
            return Collection().Find(e => e.Id == id).SingleOrDefault();
        }
        public IEnumerable<T> Query(Expression<Func<T,bool>> predicado)
        {
            return Read.Where(predicado.Compile());
        }
    }
}
