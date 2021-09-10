using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace MyBill
{
    class Products
    {
        static Products()
        {
        }
      

        public static DataTable getProduct()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "getProductList";
            return GenericDataAccess.ExecuteSelectCommand(comm);
            
        }

        public static DataTable getProduct(string ProductId)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "getProductList";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Prid";
            param.Value = ProductId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            return GenericDataAccess.ExecuteSelectCommand(comm);


        }

        public static bool DeleteProduct(string Prid)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "DeleteProduct";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PrId";
            param.Value = Prid;
            comm.Parameters.Add(param);
                      

            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return (result != -1);

        }

        public static bool UpdateProduct(string Prid,string PrCode, string PrDesc, string PrUnit, string HSNID,
            string TaxID, Decimal OpenBalance, Decimal PurchaseRate, decimal SalesRate)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "UpdateProduct";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PrId";
            param.Value = Prid;
            comm.Parameters.Add(param);


            param = comm.CreateParameter();
            param.ParameterName = "PrCode";
            param.Value = PrCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrDesc";
            param.Value = PrDesc;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@UnitId";
            param.Value = PrUnit;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@HSNID";
            param.Value = HSNID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@TaxID";
            param.Value = TaxID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrOpenBalance";
            param.Value = OpenBalance;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrPurchaseRate";
            param.Value = PurchaseRate;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrSalesRate";
            param.Value = SalesRate;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return (result != -1);

        }

        public static bool InsertProduct(string PrCode,string PrDesc,string PrUnit, string HSNID,
            string TaxID,Decimal OpenBalance, Decimal PurchaseRate, decimal SalesRate)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "InsertProduct";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "PrCode";
            param.Value = PrCode;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "PrDesc";
            param.Value = PrDesc;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "PrUnit";
            param.Value = PrUnit;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@HSNID";
            param.Value = HSNID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@TaxID";
            param.Value = TaxID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrOpenBalance";
            param.Value = OpenBalance;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrPurchaseRate";
            param.Value = PurchaseRate;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrSalesRate";
            param.Value = SalesRate;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return (result != -1);

        }

    }

}
