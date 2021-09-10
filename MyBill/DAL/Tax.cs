using MyBill.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace MyBill.DAL
{
    class Tax
    {

        static Tax()
        {
        }

        public static bool SaveTaxMaxter(MaTax tax)
        {

            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "SaveTaxMaster";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "TaxName";
            param.Value = tax.TaxName;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "CGSTCaption";
            param.Value = tax.CGSTCaption;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "CGSTTaxRate";
            param.Value = tax.CGSTTaxRate;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "SGSTCaption";
            param.Value = tax.SGSTCaption;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@SGSTTaxRate";
            param.Value = tax.SGSTTaxRate;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@IGSTCaption";
            param.Value = tax.IGSTCaption;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@IGSTTaxRate";
            param.Value = tax.IGSTTaxRate;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@UGSTCaption";
            param.Value = tax.UGSTCaption;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@UGSTTaxRate";
            param.Value = tax.UGSTTaxRate;
            param.DbType = DbType.Double;
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
