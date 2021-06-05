using System;
using System.Data.Entity;
using System.Linq;

namespace press_Agency.Models
{
    public class identityModel : DbContext
    {
        // Your context has been configured to use a 'identityModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'press_Agency.Models.identityModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'identityModel' 
        // connection string in the application configuration file.
        public DbSet<user> users { get; set; }
        public DbSet<post> posts { get; set; }
        public DbSet<Questions> questions { get; set; }
        public DbSet<Savedposts> Savedposts { get; set; }

        public identityModel()
            : base("name=identityModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}