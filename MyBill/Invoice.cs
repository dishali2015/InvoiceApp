using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace MyBill
{
    class Invoice
    {

        static Invoice()
        {
        }

        public static DataTable InvoicePrint(string InvId)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "PrintInvoice";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@InvId";
            param.Value = InvId;
           
            comm.Parameters.Add(param);        

            return GenericDataAccess.ExecuteSelectCommand(comm);


        }

        public static bool DeleteInvoice(string InvId)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "DeleteInvoice";
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@InvId";
            param.Value = InvId;
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



        public static DataTable getInvoiceMainList(DateTime InvFrom,DateTime InvTo)
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "getInvoiceMainList";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@InvFrom";
            param.Value = InvFrom;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvTo";
            param.Value = InvTo;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            return GenericDataAccess.ExecuteSelectCommand(comm);


        }


        public static DataTable getInvoiceNo()
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "getInvoiceNo";
            return GenericDataAccess.ExecuteSelectCommand(comm);

        }


        public static bool InsertInvoiceSub(int InvId, string PrId, string PrQty, 
            string PrRate, 
            string PrTaxId, 
            decimal CGSTAmount, 
            decimal SGSTAmount,
            decimal IGSTAmount,
            decimal UGSTAmount

            )
        {
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "InsertInvoiceSub";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "InvId";
            param.Value = InvId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "PrId";
            param.Value = PrId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "PrQty";
            param.Value = PrQty;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "PrRate";
            param.Value = PrRate;
            param.DbType = DbType.Double;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PrTaxId";
            param.Value = PrTaxId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceCGSTAmount";
            param.Value = CGSTAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceSGSTAmount";
            param.Value = SGSTAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceIGSTAmount";
            param.Value = IGSTAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceUGSTAmount";
            param.Value = UGSTAmount;
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

        public static bool InsertInvoiceMain(string InvoiceNo,  DateTime  InvoiceDate,
            string CustomerId, string InvGrossAmount, 
            string InvTaxAmount,
            string InvRoundOff,
            string InvNetAmount,out int InvoiceId,out string INvoiceSaveRemarks)
        {

            InvoiceId = 0;
            INvoiceSaveRemarks = "";
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "InsertInvoiceMain";

            DbParameter param = comm.CreateParameter();
            param.ParameterName = "InvoiceNo";
            param.Value = InvoiceNo;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "InvoiceDate";
            param.Value = InvoiceDate.ToString("dd-MMM-yyyy");
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);           

            param = comm.CreateParameter();
            param.ParameterName = "InvoiceCustomerId";
            param.Value = CustomerId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceGrossAmount";
            param.Value = InvGrossAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

             param = comm.CreateParameter();
            param.ParameterName = "@InvoiceTaxAmount";
            param.Value = InvTaxAmount;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceRoundOff";
            param.Value = InvRoundOff;
            param.DbType = DbType.Decimal;
            comm.Parameters.Add(param);
           
            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceNetAmount";
            param.DbType = DbType.Decimal;
            param.Value = InvNetAmount;
            comm.Parameters.Add(param);           

             param = comm.CreateParameter();
             param.ParameterName = "@InvoiceId";
             param.Direction = ParameterDirection.Output;
             param.DbType = DbType.Int32;
             comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@InvoiceSaveRemarks";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.String;
            param.Size = 1500;
            comm.Parameters.Add(param);

            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
                InvoiceId = Int32.Parse(comm.Parameters["@InvoiceId"].Value.ToString());
                INvoiceSaveRemarks = comm.Parameters["@InvoiceSaveRemarks"].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return (result != -1);

        }
    }

}
