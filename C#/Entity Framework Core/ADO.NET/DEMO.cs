private static string DemoCommandOne(SqlConnection sqlConnection)
{
    string employeesCountQuery = "SELECT COUNT(*) FROM [Employees]";
    SqlCommand employeesCountCmd =
        new SqlCommand(employeesCountQuery, sqlConnection);

    int employeesCount = (int)employeesCountCmd.ExecuteScalar();
    Console.WriteLine(employeesCount + " employees");

    string employeesDataQuery = "SELECT [FirstName], [LastName], [JobTitle] FROM [Employees]";
    SqlCommand employeesDataCmd =
        new SqlCommand(employeesDataQuery, sqlConnection);

    using SqlDataReader employeesDataReader =
        employeesDataCmd.ExecuteReader();

    int rowNumber = 1;
    StringBuilder sb = new StringBuilder();
    while (employeesDataReader.Read())
    {
        string firstName = (string)employeesDataReader["FirstName"];
        string lastName = (string)employeesDataReader["LastName"];
        string jobTitle = (string)employeesDataReader["JobTitle"];

        sb.AppendLine($"#{rowNumber++}. {firstName} {lastName} - {jobTitle}");
    }
    employeesDataReader.Close();
    return sb.ToString().TrimEnd();
}