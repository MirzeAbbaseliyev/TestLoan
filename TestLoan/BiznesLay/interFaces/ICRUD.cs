using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.Entity;

namespace TestLoan.BiznesLay.interFaces
{
    public interface ICRUD<T> where T : class, IEntity, new()
    {
        bool Delet(int id);


        List<T> GetById(int id);


        List<T> GetAll(params string[] column);


        bool Update(T t, int id);


        int RowCount();

        int Insert(T t);
        

        int RowCountWithSrc(string srcClm, string srcValue);


        List<T> getFromTo(int from, int to);

        List<T> getFromToWithSrc(int from, int to, string srcClm, string srcValue);

        List<M> Reader<M>(string CommandText, List<SqlParameter> Parameters = null) where M : class, new();
        bool NonQuery(string CommandText, List<SqlParameter> Parameters = null);


    }
}
