private static string JobTitlesAndCountCommand(SqlConnection sqlConnection) 
{
            string employeeNamesQuery = "SELECT [JobTitle], COUNT(*) AS [Count] FROM [Employees] WHERE [Salary] > 25000 GROUP BY [JobTitle] ORDER BY [Count] DESC";
            SqlCommand employeeNamesCmd =
                new SqlCommand(employeeNamesQuery, sqlConnection);
            using SqlDataReader employeeNamesReader
                = employeeNamesCmd.ExecuteReader();

            StringBuilder sb = new StringBuilder();
            while (employeeNamesReader.Read())
            {
                string jobTitle = (string)employeeNamesReader["JobTitle"];
                int count = (int)employeeNamesReader["Count"];
                sb.AppendLine($"{jobTitle} - {count}");
            }

            employeeNamesReader.Close();
            return sb.ToString().TrimEnd();
}