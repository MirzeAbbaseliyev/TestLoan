﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestLoan.BiznesLay.interFaces;
using TestLoan.Entity;

namespace TestLoan.BiznesLay
{
    public class CRUD<T>: SqlCommander,ICRUD<T> where T : class, IEntity, new()
    {
        IQuery<T> query;

        public CRUD()
        {
            query = new CreateQuery<T>();
        }

        public List<SqlParameter> SetParametrs(T t)
        {
            List<SqlParameter> parametrs = new List<SqlParameter>();
            if (t != null)
                foreach (var item in typeof(T).GetProperties())
                {
                    if (item.Name == "Id") continue;
                    object value = item.GetValue(t);
                    if (value == null) value = DBNull.Value;
                    parametrs.Add(new SqlParameter($"@{item.Name}", value));
                }
            return parametrs;
        }


        public virtual int Insert(T t)
        {
            string cmtext = query.Insert() + " ;SELECT CAST(scope_identity() AS int)";
            var p = SetParametrs(t);
            var id = Scaller(cmtext, p);
            if (id != null) return Convert.ToInt32(id);
            else return 0;
        }

        public virtual bool Delet(int id)
        {
            string cmtext = query.Delete(id.ToString());
            if (NonQuery(cmtext)) return true;
            return false;
        }

        public virtual List<T> GetById(int id)
        {
            string cmtext = query.GetById();

            return Reader<T>(cmtext, new List<SqlParameter>() {
                new SqlParameter("@Id",id)});
        }

        public virtual List<T> GetAll(params string[] column)
        {
            string cmtext = query.GetAll(column);
            return Reader<T>(cmtext);
        }

        public virtual bool Update(T t, int id)
        {

            string cmtext = query.Update(id.ToString());
            var p = SetParametrs(t);
            if (NonQuery(cmtext,p))                       
                return true;          
            
            return false;
        }

        public virtual int RowCount()
        {
            string cmtext = query.RowCount();
            var o = Scaller(cmtext);
            if (o != null) return Convert.ToInt32(o);
            else return 0;
        }

        public virtual int RowCountWithSrc(string srcClm, string srcValue)
        {

            string cmtext= query.RowCountWithSrc(srcClm);
            var o = Scaller(cmtext,new List<SqlParameter> { new SqlParameter("@srcClm", srcValue)});
            if (o != null) return Convert.ToInt32(o);
            else return 0;
        }

        public virtual List<T> getFromTo(int from, int to)
        {
            string cmtext = query.getFromTo(from, to);           
            return Reader<T>(cmtext);
        }

        public virtual List<T> getFromToWithSrc(int from, int to, string srcClm, string srcValue)
        {
            string cmtext = query.getFromToWithSrc(from, to, srcClm);            
            return Reader<T>(cmtext,new List<SqlParameter> { new SqlParameter("@srcClm", srcValue)});
        }
    }
}
