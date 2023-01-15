namespace Infrastructure.Services;
using Domain.Entities;
using Npgsql;
using Dapper;
public class QuoteService
{
 private string _connectionString = "Server=127.0.0.1;Port=5432;Database=quotedb;User Id=postgres;Password=admin;";

 public QuoteService()
 {
    
 }

 public List<Quote> GetQuotes(){
    using (var connection=new NpgsqlConnection(_connectionString)){
        var sql ="select * from Quotes order by id;";
        var result = connection.Query<Quote>(sql);
        return result.ToList();
    }
 }
 public List<Quote> GetBycategoryId(int id){
    using (var connection=new  NpgsqlConnection(_connectionString)){
        var sql=$" select * from Quotes WHERE CategoryId={id};";
        var resultt=connection.Query<Quote>(sql);
        return resultt.ToList();
    }
 }
public List<Quote> GetRandom(){
    using(var connection=new NpgsqlConnection(_connectionString)){
        var sql=$"select * from Quotes ORDER by random() limit 1;";
        var resulttt=connection.Query<Quote>(sql);
        return resulttt.ToList();
    }
}

public bool DeleteID(int id){
    using(var connection=new NpgsqlConnection(_connectionString)){
        var sql = $"delete from Quotes where id={id};";
        var delete=connection.Execute(sql);
        if(delete>0) return true;
        else return false;
    }
}

public bool UpdateQuote(Quote quote){
    using (var connection =new NpgsqlConnection(_connectionString)){
        var sql =$"update Quotes set author='{quote.Author}',quotetext='{quote.QuoteText}',CategoryId={quote.CategoryId} where id={quote.Id};";
        var update=connection.Execute(sql);
        if(update>0)return true;
        else return false;
    }
}

public bool AddQuote(Quote quote){
    using(var connection=new NpgsqlConnection(_connectionString)){
        var sql = $"insert into Quotes (author,quotetext,CategoryId) values ('{quote.Author}','{quote.QuoteText}',{quote.CategoryId});";
        var addd=connection.Execute(sql);
        if(addd>0)return true ;
        else return false;
    }
}

}
