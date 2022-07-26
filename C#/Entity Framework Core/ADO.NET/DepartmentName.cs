private static string DepartmentName(SqlConnection sqlConnection) 
{
            StringBuilder sb = new StringBuilder();
            int departmentId = int.Parse(Console.ReadLine());

            string departmentNameByIdQuery = $"SELECT [Name] FROM Departments WHERE DepartmentID = {departmentId}";
            SqlCommand departmentNameByIdCmd =
                new SqlCommand(departmentNameByIdQuery, sqlConnection);
            string depatrmentName = (string)departmentNameByIdCmd.ExecuteScalar();
            if (depatrmentName != null)
            {
                Console.WriteLine($"Department Name: {depatrmentName}");
            }
            else 
            {
                return $"No department with ID {departmentId} exists in the database.";
            }

            string query = $"SELECT e.FirstName AS [Name], e.ManagerID, d.[Name] AS [Department Name] FROM [Employees] AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID WHERE e.DepartmentID = {departmentId} ORDER BY [Name]";
            SqlCommand command
                = new SqlCommand(query, sqlConnection);
            using SqlDataReader departmentNameReader
                = command.ExecuteReader();
            
            int i = 1;
            while (departmentNameReader.Read())
            {
                string employeeName = (string)departmentNameReader["Name"];
                int managerID = (int)departmentNameReader["ManagerID"];
                sb.AppendLine($"{i++}. {employeeName} - {managerID}");
            }
            departmentNameReader.Close();

            return sb.ToString().TrimEnd();
}