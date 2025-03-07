using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mymvc.Models;

namespace mymvc.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Models.Monitor> Monitors { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>().HasKey(t => new { t.TESTID, t.CourseId });

            modelBuilder.Entity<Models.Monitor>().HasKey(t => new { t.CourseId, t.LID });

            modelBuilder.Entity<Lecturer>().HasData(
                new Lecturer
                {
                    LID = 1,
                    EMAIL = "UIroh@hcmut.edu.vn",
                    FULL_NAME = "Uncle Iroh",
                    PHONE_NUMBER = "0987654321",
                    DEPARTMENT = "Engineering"
                },
                new Lecturer
                {
                    LID = 2,
                    EMAIL = "EFMark@hcmut.edu.vn",
                    FULL_NAME = "Mark Edward Fischbach",
                    PHONE_NUMBER = "0135791113",
                    DEPARTMENT = "Computer Science"
                }

            );
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    ScheduleId = 1,
                    CourseId = 1,
                    Time = new TimeSpan(9, 0, 0), // 9:00 AM
                    Date = new DateTime(2024, 12, 10),
                    Location = "Room A1, 101"
                },
                new Schedule
                {
                    ScheduleId = 2,
                    CourseId = 2,
                    Time = new TimeSpan(13, 30, 0), // 1:30 PM
                    Date = new DateTime(2024, 12, 11),
                    Location = "Room B2, 102"
                }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    CourseName = "Mathematics",
                    Credit = 3,
                    Department = "Engineering",
                    Description = "A course on advanced mathematics."
                },
                new Course
                {
                    CourseId = 2,
                    CourseName = "Computer Networks",
                    Credit = 4,
                    Department = "Computer Science",
                    Description = "Learn the fundamentals of computer networking."
                },

                new Course
                {
                    CourseId = 3,
                    CourseName = "Introduction to AI",
                    Credit = 3,
                    Department = "Computer Science",
                    Description = "Learn the fundamentals of Artificial Intelligent."
                }

            );

            modelBuilder.Entity<Category>().HasData(
                new Category {Id = 1, Name = "Test" , DisplayOrder = 2},
                new Category { Id = 2, Name = "Somthin", DisplayOrder = 3 },
                new Category { Id = 3, Name = "okkk", DisplayOrder = 4 }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    CategoryID = 3
                }
            );
        }
    }
}