namespace Infrastructure.Services;
using Domain.Entities;
using Npgsql;
using Dapper;
public class CategoryService
{
 private string _connectionString = "Server=127.0.0.1;Port=5432;Database=quotedb;User Id=postgres;Password=admin;";

 public CategoryService()
 {
    
 }

 public List<Categor> GetCat(){
    using (var connection=new NpgsqlConnection(_connectionString)){
        var sql ="select * from Categories;";
        var result = connection.Query<Categor>(sql);
        return result.ToList();
    }
 }

public bool AddCat(Categor categor){
    using(var connection=new NpgsqlConnection(_connectionString)){
        var sql = $"insert into Categories (category) values ('{categor.Category}');";
        var addd=connection.Execute(sql);
        if(addd>0)return true ;
        else return false;
    }
}



}
