using ApiProject.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProject.WebApi.Context
{
    //code first
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-861CR38\\SQLEXPRESS;initial catalog=ApiYummpDb;integrated security=true;");
        }
        //oluşacak db tablosunun adı categories olacak
        public DbSet<Category> Categories { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<YummyEvent> YummyEvents{ get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<About> Abouts{ get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<EmployeeTaskChef> EmployeeTaskChefs { get; set; }
        public DbSet<GroupReservation> GroupReservations { get; set; }
        //Migration İÇİN: 
        //  paket yönetim konsolu açılır
        //  add-migration mig1 ->komutu yazılır ve migration dosayası böylece oluşturulmuş olur
        //  update-database ->komutu ile migration işlemi database yönlendriilir. burada mssql kullandım
    }
}
