using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Models;
using NZWalksAPI.Models.Domains;

namespace NZWalksAPI.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
        {
                
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed data for difficulties
            // Easy, Meduim, Hard
           var difficulties = new List<Difficulty>()
           {
              new Difficulty()
              {
                  Id = Guid.Parse("75013f4d-ed65-4895-86cf-5b38ab275226"),
                  Name = "Easy"
              },
              new Difficulty()
              {
                  Id = Guid.Parse("be65a116-7e9a-4ff9-a68c-9fa2d8dd3d95"),
                  Name = "Medium"
              },
              new Difficulty()
              {
                  Id = Guid.Parse("2c6e3638-ec00-4046-be62-9c55c3c98288"),
                  Name = "Hard"
              },
           };

            //Seed dificulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Region
            var regions = new List<Region>()
           {
              new Region
              {
                  Id = Guid.Parse("09946c96-29cc-4645-b231-4b4c2a6c0582"),
                  Name = "Calgary",
                  Code = "YYC",
                  RegionImageUrl = "https://peakvisor.com/img/news/Calgary-Alberta.jpg"
              },
              new Region
              {
                  Id = Guid.Parse("03cbe871-635e-4b27-a437-7d210ddaff9b"),
                  Name = "Vancouver",
                  Code = "YVR",
                  RegionImageUrl = "https://vancouver.ca/images/cov/feature/geography-landing.jpg"
              },
              new Region
              {
                  Id = Guid.Parse("aa94477c-78e7-4115-9617-550966e52c52"),
                  Name = "Toronto",
                  Code = "YYZ",
                  RegionImageUrl = "https://a.travel-assets.com/findyours-php/viewfinder/images/res70/516000/516652-nathan-phillips-square.jpg"
              },
              new Region
              {
                  Id = Guid.Parse("c1e5a259-6b1c-4c54-99a5-820dfd054eef"),
                  Name = "Montreal",
                  Code = "YUL",
                  RegionImageUrl = "https://www.airtransat.com/getmedia/cafc7e6e-d0ff-497e-9998-e708f41aa191/Montreal-estival.aspx"
              },
              new Region
              {
                  Id = Guid.Parse("1e09e80f-7e25-492b-a136-53fa8a92c277"),
                  Name = "New York",
                  Code = "JFK",
                  RegionImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/View_of_Empire_State_Building_from_Rockefeller_Center_New_York_City_dllu_%28cropped%29.jpg/1200px-View_of_Empire_State_Building_from_Rockefeller_Center_New_York_City_dllu_%28cropped%29.jpg"
              },
              new Region
              {
                  Id = Guid.Parse("da9c333c-ae19-4526-9016-8cb90dea02f1"),
                  Name = "Los Angles",
                  Code = "LAX",
                  RegionImageUrl = "https://www.visittheusa.com/sites/default/files/styles/hero_l/public/images/hero_media_image/2017-01/Getty_515070156_EDITORIALONLY_LosAngeles_HollywoodBlvd_Web72DPI_0.jpg?h=0a8b6f8b&itok=lst_2_5d"
              },
              
           };

            // Seed Region to database
            modelBuilder.Entity<Region>().HasData(regions);

        }


    }
}
