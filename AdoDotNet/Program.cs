using AdoDotNet;
string connectionString = "Server=DESKTOP-IDIVHCD\\SQLEXPRESS;Database=AdoDotNet;User Id=AdoDotNet;Password=123456;";
DataUility dataUility= new DataUility(connectionString);
var sql = "update Students set CGPA = 3.66,DateOfBirth='2022-01-05' where id=4";
//dataUility.ExecuteCommand(sql);
var query = "select * from students";

var values=dataUility.ExecuteQuery(query);
foreach (var items in values)
{
    foreach (var key in items.Keys)
    {
        Console.WriteLine($"{key}={items[key]}");
    }
}
