using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TableMates.Models;

namespace TableMates.DAL
{
    public class TableMatesInitializer : DropCreateDatabaseIfModelChanges<TablematesContext>
    {
        protected override void Seed(TablematesContext context)
        {
            var newuser = new User { username = "test", email = "test@test.com" };
            context.Users.Add(newuser);

            var newappointment = new Appointment { ID = 1, Lat = float.Parse("-87.68348"), Lng = float.Parse("41.96064"), MaxAttendees = 4, MinAttendees = 2, AppointmentDate = DateTime.Parse("2003-09-01"), RestaurantName = "Lou\'s", Users = null, AppointmentName = "First Time", };
            context.Appointments.Add(newappointment);

            context.SaveChanges();
        }
    }
}