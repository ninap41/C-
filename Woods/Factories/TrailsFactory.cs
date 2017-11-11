using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data; 
using Woods.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


 
namespace Woods.Factory
{
    public class TrailFactory : IFactory<Trails>
    {


        private readonly IOptions<MySqlOptions> MySqlConfig;
        
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        public TrailFactory(IOptions<MySqlOptions> mySqlConfig)
        {
            MySqlConfig = mySqlConfig;
        }   
        


        
        public void Add(Trails trails)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO trails (trail_name, description,trail_length, elevation_change, latitude,longitude) VALUES ('{trails.Trail_Name}', {trails.Description}, '{trails.Trail_Length}', {trails.Elevation_Change}, {trails.Latitude}, '{trails.Longitude}')";
               
                dbConnection.Open();
                dbConnection.Execute(query, trails);
                
            }
        }
            public IEnumerable<Trails> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                return dbConnection.Query<Trails>("SELECT * FROM trails");
            }
        }

      
      }     
            
}

