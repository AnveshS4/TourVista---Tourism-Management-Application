
using System;
using System.Data;
using System.Data.SqlClient;
using Tourism.BusinessInfo;

/// <summary>
/// Database operations on Address table.
/// </summary>
namespace Tourism.DataAccess
{
    public class Address
    {
        /// <summary>
        /// To insert data into address table.
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <param name="dataAccess"></param>
        public void InsertAddress(AddressInfo addressInfo, DataAccess dataAccess)
        {
            /*This method doesn't need to open/close database connection because it is using parent connection information.*/
            FillParameters(addressInfo, "Insert", dataAccess);
            dataAccess.ExecuteNonQuery(DbCommands.sp_InsetUpdateAddress);
            /*Assigning addressID after inserting the data into address table.*/
            addressInfo.AddressId = Convert.ToInt32(dataAccess.Parameters["@AddressId"].Value);
        }

        /// <summary>
        /// Updates address table.
        /// </summary>
        /// <param name="addressInfo"></param>
        /// <param name="dataAccess"></param>
        internal void UpdateAddress(AddressInfo addressInfo, DataAccess dataAccess)
        {
            /*This method doesn't need to open/close database connection because it is using parent connection information.*/
            FillParameters(addressInfo, "Update", dataAccess);
            dataAccess.ExecuteNonQuery(DbCommands.sp_InsetUpdateAddress);
        }

        private void FillParameters(AddressInfo addressInfo, string action, DataAccess dataAccess)
        {
            dataAccess.Parameters.AddWithValue("@Address1", addressInfo.Address1);
            dataAccess.Parameters.AddWithValue("@Address2", addressInfo.Address2);
            dataAccess.Parameters.AddWithValue("@State", addressInfo.State);
            dataAccess.Parameters.AddWithValue("@City", addressInfo.City);
            dataAccess.Parameters.AddWithValue("@Zip", addressInfo.Zip);
            dataAccess.Parameters.AddWithValue("@Action", action);

            /*Declaring SQL parameter as output which helps to retrieve the id after performing insert operation*/
            SqlParameter addressId = new SqlParameter();
            addressId.ParameterName = "@AddressId";
            addressId.Value = addressInfo.AddressId;
            addressId.Direction = ParameterDirection.InputOutput;
            addressId.DbType = DbType.Int32;
            dataAccess.Parameters.Add(addressId);
        }
    }
}